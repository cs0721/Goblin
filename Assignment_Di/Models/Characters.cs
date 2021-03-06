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

    public partial class Characters
    {
        public int CharacterID { get; set; }
        [Required(ErrorMessage = "Please Enter Character Name")]
        public string CharacterName { get; set; }
        [Required(ErrorMessage = "Please Enter Character Description")]
        public string CharacterDescription { get; set; }
        [Required(ErrorMessage = "Please Select Character Group")]
        public string CharacterGroup { get; set; }
        [Required(ErrorMessage = "Please Select Actor ID")]
        public int ActorID { get; set; }
    
        public virtual Actors Actors { get; set; }
    }
}
