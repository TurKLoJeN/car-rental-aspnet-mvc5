//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSTCarRental.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLKIRALA
    {
        public int ID { get; set; }
        public Nullable<int> ARABA { get; set; }
        public string ISIM { get; set; }
        public string MAIL { get; set; }
        public string TELEFON { get; set; }
        public Nullable<System.DateTime> ALISTARIH { get; set; }
        public Nullable<System.DateTime> GETIRTARIH { get; set; }
        public bool DURUM { get; set; }
    
        public virtual TBLARABA TBLARABA { get; set; }
    }
}
