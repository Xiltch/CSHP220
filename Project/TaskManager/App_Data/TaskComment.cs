//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManager.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskComment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int CreatedBy { get; set; }
        public string Details { get; set; }
        public System.DateTime Created { get; set; }
    
        public virtual Task Task { get; set; }
        public virtual TaskUser CreatedUser { get; set; }
    }
}
