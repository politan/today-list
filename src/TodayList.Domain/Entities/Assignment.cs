using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodayList.Domain.Common;
using TodayList.Domain.Enums;

namespace TodayList.Domain.Entities
{
    public class Assignment : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? RemindDate { get; set; }
        public bool Finished { get; set; }
        public PriorityLevel Priority { get; set; }
        public Guid ProjectId { get; set; }
        
        public Project Project { get; set; }
    }
}