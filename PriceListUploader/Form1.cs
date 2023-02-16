using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using CsvHelper;
using System.Globalization;
namespace PriceListUploader
{
    public partial class Form1 : Form
    {
        private string importfile = "";
        private string[] extractfiles;
        private string[] missingimages;
        private string attachmentfolder = "";
        private string extractname = "";
        private int toupdate = 0;
        private int toappend = 0;
        private int errors = 0;
        private List<ImportLine> records;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public string GetFiles()
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    extractfiles = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + extractfiles.Length.ToString(), "Message");
                    return fbd.SelectedPath;
                }
                else
                {
                    return "No location selected";
                }
            }

        }

        private void supplierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_designdbDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_designdbDataSet.ProductAreas' table. You can move, or remove it, as needed.
            this.productAreasTableAdapter.Fill(this.sbi_designdbDataSet.ProductAreas);
            // TODO: This line of code loads data into the 'sbi_designdbDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.FillBySorted(this.sbi_designdbDataSet.Supplier);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            toupdate = 0;
            toappend = 0;
            int sid = (int)comboBox1.SelectedValue;
            string supname = this.sbi_designdbDataSet.Supplier.FindBySupplierID((int)comboBox1.SelectedValue).SupplierName;
            this.supplierProductsTableAdapter1.FillBySupplierID(this.sbi_designdbDataSet.SupplierProducts, (Int32)comboBox1.SelectedValue);
            var FD = new System.Windows.Forms.OpenFileDialog();
            DialogResult result =FD.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
               importfile = FD.FileName;
               
            }
            using (var reader = new StreamReader(importfile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<ImportLine>().ToList();

                foreach(var item in records)
                {
                    var match = this.sbi_designdbDataSet.SupplierProducts.Where(s => s.ProductCode == item.ProductCode && s.SupplierID == sid).FirstOrDefault();

                    if (match != null)
                    {
                        toupdate++;
                    }
                    else
                    {
                        toappend++;
                    }
                }
                System.Windows.Forms.MessageBox.Show(supname.ToUpper() + "\nProducts to append: " + toappend + "\nProducts to update: " + toupdate, "Message");
            }
        }
        private void HandleImages(ImportLine line, int id)
        {
            string[] files = { line.Imagename1, line.Imagename2, line.Imagename3, line.Imagename4, line.Imagename5, line.Imagename6, line.Imagename7, line.Imagename8, line.Imagename9 };
            string prepend = "/images/" + (int)comboBox1.SelectedValue + "/";
            foreach (string f in files)
            {
                if (!String.IsNullOrWhiteSpace(f))
                {
                    int imid = 0;
                    var imgstr = prepend + f;
                    this.imageFilesTableAdapter1.FillByLocation(this.sbi_designdbDataSet.ImageFiles, imgstr);
                    var imgln = this.sbi_designdbDataSet.ImageFiles.FirstOrDefault();
                    if (imgln == null)
                    {
                        imgln = this.sbi_designdbDataSet.ImageFiles.NewImageFilesRow();
                        imgln["ImageLocation"] = imgstr;
                        this.sbi_designdbDataSet.ImageFiles.Rows.Add(imgln);
                        this.imageFilesTableAdapter1.Update(imgln);


                    }

                    imid = imgln.ImageID;

                    this.supplierProductImagesTableAdapter1.FillBySupplierProduct(this.sbi_designdbDataSet.SupplierProductImages, id);
                    if (!this.sbi_designdbDataSet.SupplierProductImages.ToList().Where(s => s.ImageID == imid).Any())
                    {
                        var spiln = this.sbi_designdbDataSet.SupplierProductImages.NewSupplierProductImagesRow();
                        spiln["SupplierProductID"] = id;
                        spiln["ImageID"] = imid;
                        this.sbi_designdbDataSet.SupplierProductImages.Rows.Add(spiln);
                        this.supplierProductImagesTableAdapter1.Update(spiln);
                    } 
                }
               

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            toupdate = 0;
            toappend = 0;
            int sid = (int)comboBox1.SelectedValue;
            int aid = (int)comboBox2.SelectedValue;
            string areaname = this.sbi_designdbDataSet.ProductAreas.FindByProductAreaID((int)comboBox2.SelectedValue).Name;
            this.supplierProductsTableAdapter1.FillBySupplierID(this.sbi_designdbDataSet.SupplierProducts, (Int32)comboBox1.SelectedValue);
            this.productTypesTableAdapter1.Fill(this.sbi_designdbDataSet.ProductTypes);
            var types = records.GroupBy(s => s.ProductType).Select(s => s.Key).ToList();
            var existing = this.sbi_designdbDataSet.ProductTypes.Select(s => s.Name).ToList();
            var newtypes = types.Except(existing);
            var createtypes = new DialogResult();
            if (newtypes.Any()) { createtypes = MessageBox.Show("The following types will be created: " + String.Join(", ", newtypes) + " -with default area " + areaname, "New Types", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); };
            if (!newtypes.Any() || createtypes == DialogResult.OK)
            {
                if (newtypes.Any())
                {
                    foreach (var t in newtypes)
                    {
                        var tr = this.sbi_designdbDataSet.ProductTypes.NewRow();
                        tr["Name"] = t;
                        tr["DefaultAreaID"] = aid;

                        this.sbi_designdbDataSet.ProductTypes.Rows.Add(tr);
                        this.productTypesTableAdapter1.Update(this.sbi_designdbDataSet.ProductTypes);
                    }
                }

                foreach (var item in records)
                {
                    if (!(String.IsNullOrWhiteSpace(item.ProductCode)))
                    {
                        var match = this.sbi_designdbDataSet.SupplierProducts.Where(s => s.ProductCode == item.ProductCode && s.SupplierID == sid).FirstOrDefault();

                        if (match != null)
                        {
                            match.Item = !String.IsNullOrWhiteSpace(item.Item) ? item.Item : match.Item;
                            match.Description = !String.IsNullOrWhiteSpace(item.Description) ? item.Description : match.Description;
                            match.Colour = !String.IsNullOrWhiteSpace(item.Colour) ? item.Colour : match.Colour;
                            match.Dimensions = !String.IsNullOrWhiteSpace(item.Dimensions) ? item.Dimensions : match.Dimensions;
                            match.Weight = (item.Weight != null) ? (decimal)item.Weight : match.Weight;
                            match.Quantity = (item.Quantity != null) ? (decimal)item.Quantity : match.Quantity;
                            match.UnitPrice = (item.UnitPrice != null) ? (decimal)item.UnitPrice : match.UnitPrice;
                            match.ProductType = this.sbi_designdbDataSet.ProductTypes.Where(s => s.Name == item.ProductType).FirstOrDefault().ProductTypeID;
                            match.SupplierProductStatusID = 1;
                            match.DateUpdated = DateTime.Now;
                            this.supplierProductsTableAdapter1.Update(match);
                            HandleImages(item, match.SupplierProductID);
                            toupdate++;
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(item.ProductType))
                            {
                                match = this.sbi_designdbDataSet.SupplierProducts.NewSupplierProductsRow();
                                match.Item = !String.IsNullOrWhiteSpace(item.Item) ? item.Item : "";
                                match.SupplierID = sid;
                                match.ProductCode = item.ProductCode;
                                match.Description = !String.IsNullOrWhiteSpace(item.Description) ? item.Description : "";
                                match.Colour = !String.IsNullOrWhiteSpace(item.Colour) ? item.Colour : "";
                                match.Dimensions = !String.IsNullOrWhiteSpace(item.Dimensions) ? item.Dimensions : "";
                                match.Weight = (item.Weight != null) ? (decimal)item.Weight : 0;
                                match.Quantity = (item.Quantity != null) ? (decimal)item.Quantity :0;
                                match.UnitPrice = (item.UnitPrice != null) ? (decimal)item.UnitPrice : 0;
                                match.ProductType = this.sbi_designdbDataSet.ProductTypes.Where(s => s.Name == item.ProductType).FirstOrDefault().ProductTypeID;
                                match.SupplierProductStatusID = 1;
                                match.DateUpdated = DateTime.Now;
                                this.sbi_designdbDataSet.SupplierProducts.Rows.Add(match);
                                this.supplierProductsTableAdapter1.Update(match);

                                HandleImages(item, match.SupplierProductID);


                                toappend++;
                            }
                            else
                            {
                                errors++;
                            }
                           
                        } 
                    }
                    else
                    {
                        errors++;
                    }
                } 
            }
        }

        private void fillBySortedToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.supplierTableAdapter.FillBySorted(this.sbi_designdbDataSet.Supplier);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
