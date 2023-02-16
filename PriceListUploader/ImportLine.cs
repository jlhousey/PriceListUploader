using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace PriceListUploader
{
    class ImportLine
    {
        
       
        public string Item { get; set; }
        
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
       
        public string Dimensions { get; set; }
        public decimal? Weight { get; set; }
      
        public decimal? Quantity { get; set; }
        
        public decimal? UnitPrice { get; set; }
        
        public string ProductType { get; set; }
        [Optional]
        public int? ProductTypeID { get; set; }
        public string Imagename1 { get; set; }
        public string Imagename2 { get; set; }
        public string Imagename3 { get; set; }
        public string Imagename4 { get; set; }
        public string Imagename5 { get; set; }
        public string Imagename6 { get; set; }
        public string Imagename7 { get; set; }
        public string Imagename8 { get; set; }
        public string Imagename9 { get; set; }





    }
}
