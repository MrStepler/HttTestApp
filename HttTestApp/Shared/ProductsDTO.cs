using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HttTestApp.Shared
{
    public class ProductsDTO
    {
        public long Article { get; set; }
        
        public string ProductName { get; set; }
        public float Cost { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public List<string?>? Categories { get; set; }
    }
}
