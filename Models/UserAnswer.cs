//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CellableMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAnswer
    {
        public int AnswerId { get; set; }
        public bool Answer { get; set; }
        public int PossibleDefectId { get; set; }
        public int UserPhoneId { get; set; }
        public Nullable<int> DefectGroupId { get; set; }
        public Nullable<int> UserAnswerId { get; set; }
    
        public virtual PossibleDefect PossibleDefect { get; set; }
        public virtual UserPhone UserPhone { get; set; }
    }
}
