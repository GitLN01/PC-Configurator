using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PC
    {
        public int Id { get; set; }
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Motherboard { get; set; }
        public string Storage { get; set; }
        public string Case { get; set; }
        public string PSU { get; set; }
        public string Description { get; set; }


    }
}
