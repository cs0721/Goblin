//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_Di.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Actors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actors()
        {
            this.Characters = new HashSet<Characters>();
        }
    
        public int ActorID { get; set; }
        [Required(ErrorMessage = "Please Enter Actor Name")]
        public string ActorName { get; set; }
        [Required(ErrorMessage = "Please Enter Actor DOB")]
        public System.DateTime ActorDOB { get; set; }
        [Required(ErrorMessage = "Please Select Actor Gender")]
        public string ActorGender { get; set; }
        [Required(ErrorMessage = "Please Enter Actor Nationality")]
        public string ActorNationality { get; set; }
        public string ActorHeight { get; set; }
        public string ActorWeight { get; set; }
        public string ActorBloodType { get; set; }
        public string ActorStarSign { get; set; }
        [Required(ErrorMessage = "Please Enter Actor Debut Year")]
        public Nullable<int> ActorDebutYear { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Characters> Characters { get; set; }
    }
}