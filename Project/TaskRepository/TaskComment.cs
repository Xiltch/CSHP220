//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskComment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public System.DateTime Date { get; set; }
        public int CreatedBy { get; set; }
        public string Details { get; set; }
    
        public virtual Task Task { get; set; }
        public virtual TaskUser TaskUser { get; set; }
    }
}
