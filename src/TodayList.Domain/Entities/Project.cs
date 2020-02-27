using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodayList.Domain.Common;

namespace TodayList.Domain.Entities
{
    public class Project : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}