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
    
    public partial class TB_PROCEDURE_EXPEDITION
    {
        public int Id { get; set; }
        public Nullable<int> Etat { get; set; }
        public string TexteLog { get; set; }
        public Nullable<int> DefautLog { get; set; }
        public Nullable<int> IdExpedition { get; set; }
    
        public virtual TB_EXPEDITION TB_EXPEDITION { get; set; }
    }
}
