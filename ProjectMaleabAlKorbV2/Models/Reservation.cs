//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectMaleabAlKorbV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int reservationNo { get; set; }
        public System.TimeSpan reservationTime { get; set; }
        public System.DateTime reservationDate { get; set; }
        public Nullable<System.DateTime> dateReservation { get; set; }
        public Nullable<int> playerNo { get; set; }
        public Nullable<int> stadiumNo { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}
