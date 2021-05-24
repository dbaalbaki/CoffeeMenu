using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace NewMenu.Models
{
  
    [Table("menu")]
    public class Menu
    {
        [Key]
        public int id { get; set; }
        public string productname { get; set; }
        public string discription { get; set; }
        public string price { get; set; }
        public string category { get; set; }

    }
}

