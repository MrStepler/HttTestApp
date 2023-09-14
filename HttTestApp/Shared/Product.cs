using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttTestApp.Shared
{
    public class Product
    {
        [Key]
        public long Article { get; set; }
        [Required]
        public string ProductName { get; set; }
        public float Cost { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }

    }
}
