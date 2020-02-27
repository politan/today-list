using System;
using TodayList.Domain.Enums;

namespace TodayList.Application.DTO
{
    public class AssignmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? RemindDate { get; set; }
        public bool Finished { get; set; }
        public PriorityLevel Priority { get; set; }
    }
}