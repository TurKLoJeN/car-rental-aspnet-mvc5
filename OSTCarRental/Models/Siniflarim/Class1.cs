using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OSTCarRental.Models.Entity;   
namespace OSTCarRental.Models.Siniflarim
{
    public class Class1
    {
        public IEnumerable<TBLARABA> Araba { get; set; }
        public IEnumerable<TBLKATEGORI> Kategori { get; set; }
        public IEnumerable<TBLKIRALA> Kirala { get; set; }
    }
}