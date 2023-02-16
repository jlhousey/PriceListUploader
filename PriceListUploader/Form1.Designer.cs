namespace PriceListUploader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sbi_designdbDataSet = new PriceListUploader.sbi_designdbDataSet();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierTableAdapter = new PriceListUploader.sbi_designdbDataSetTableAdapters.SupplierTableAdapter();
            this.tableAdapterManager = new PriceListUploader.sbi_designdbDataSetTableAdapters.TableAdapterManager();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.supplierProductsTableAdapter1 = new PriceListUploader.sbi_designdbDataSetTableAdapters.SupplierProductsTableAdapter();
            this.productTypesTableAdapter1 = new PriceListUploader.sbi_designdbDataSetTableAdapters.ProductTypesTableAdapter();
            this.productAreasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productAreasTableAdapter = new PriceListUploader.sbi_designdbDataSetTableAdapters.ProductAreasTableAdapter();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageFilesTableAdapter1 = new PriceListUploader.sbi_designdbDataSetTableAdapters.ImageFilesTableAdapter();
            this.supplierProductImagesTableAdapter1 = new PriceListUploader.sbi_designdbDataSetTableAdapters.SupplierProductImagesTableAdapter();
            this.fillBySortedToolStrip = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_designdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productAreasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Image File Location";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // sbi_designdbDataSet
            // 
            this.sbi_designdbDataSet.DataSetName = "sbi_designdbDataSet";
            this.sbi_designdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataMember = "Supplier";
            this.supplierBindingSource.DataSource = this.sbi_designdbDataSet;
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ImageFilesTableAdapter = null;
            this.tableAdapterManager.ProductAreasTableAdapter = null;
            this.tableAdapterManager.ProductTypesTableAdapter = null;
            this.tableAdapterManager.SupplierProductImagesTableAdapter = null;
            this.tableAdapterManager.SupplierProductsTableAdapter = null;
            this.tableAdapterManager.SupplierTableAdapter = this.supplierTableAdapter;
            this.tableAdapterManager.UpdateOrder = PriceListUploader.sbi_designdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.supplierBindingSource;
            this.comboBox1.DisplayMember = "SupplierName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(39, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ValueMember = "SupplierID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Supplier";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(42, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Select Upload File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(42, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(147, 32);
            this.button4.TabIndex = 7;
            this.button4.Text = "Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // supplierProductsTableAdapter1
            // 
            this.supplierProductsTableAdapter1.ClearBeforeFill = true;
            // 
            // productTypesTableAdapter1
            // 
            this.productTypesTableAdapter1.ClearBeforeFill = true;
            // 
            // productAreasBindingSource
            // 
            this.productAreasBindingSource.DataMember = "ProductAreas";
            this.productAreasBindingSource.DataSource = this.sbi_designdbDataSet;
            // 
            // productAreasTableAdapter
            // 
            this.productAreasTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.productAreasBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(39, 100);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(299, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.ValueMember = "ProductAreaID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Default Product Area (for new product types)";
            // 
            // imageFilesTableAdapter1
            // 
            this.imageFilesTableAdapter1.ClearBeforeFill = true;
            // 
            // supplierProductImagesTableAdapter1
            // 
            this.supplierProductImagesTableAdapter1.ClearBeforeFill = true;
            // 
            // fillBySortedToolStrip
            // 
            this.fillBySortedToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillBySortedToolStrip.Name = "fillBySortedToolStrip";
            this.fillBySortedToolStrip.Size = new System.Drawing.Size(487, 25);
            this.fillBySortedToolStrip.TabIndex = 10;
            this.fillBySortedToolStrip.Text = "fillBySortedToolStrip";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 298);
            this.Controls.Add(this.fillBySortedToolStrip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_designdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productAreasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private sbi_designdbDataSet sbi_designdbDataSet;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private sbi_designdbDataSetTableAdapters.SupplierTableAdapter supplierTableAdapter;
        private sbi_designdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private sbi_designdbDataSetTableAdapters.SupplierProductsTableAdapter supplierProductsTableAdapter1;
        private sbi_designdbDataSetTableAdapters.ProductTypesTableAdapter productTypesTableAdapter1;
        private System.Windows.Forms.BindingSource productAreasBindingSource;
        private sbi_designdbDataSetTableAdapters.ProductAreasTableAdapter productAreasTableAdapter;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private sbi_designdbDataSetTableAdapters.ImageFilesTableAdapter imageFilesTableAdapter1;
        private sbi_designdbDataSetTableAdapters.SupplierProductImagesTableAdapter supplierProductImagesTableAdapter1;
        private System.Windows.Forms.ToolStrip fillBySortedToolStrip;
    }
}

