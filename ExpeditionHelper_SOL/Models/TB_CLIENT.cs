//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpeditionHelper_SOL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_CLIENT()
        {
            this.TB_ADRESSE = new HashSet<TB_ADRESSE>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ADRESSE> TB_ADRESSE { get; set; }
    }
}