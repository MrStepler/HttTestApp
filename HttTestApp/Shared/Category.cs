using HttTestApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttTestApp
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public long? ProductArticle { get; set; }
        [ForeignKey("ProductArticle")]
        public Product? Product { get; set; }
    }
}
