//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            this.TBLSATİSLAR = new HashSet<TBLSATİSLAR>();
        }
    
        public int MUSTERIID { get; set; }

        [Required (ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        [StringLength (10,ErrorMessage ="En Fazla 10 karakterlik isim giriniz..!")]
        public string MUSTERIAD { get; set; }

        [Required (ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        [StringLength (10,ErrorMessage ="En Fazla 10 karakterlik soyad giriniz..!")]
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATİSLAR> TBLSATİSLAR { get; set; }
    }
}