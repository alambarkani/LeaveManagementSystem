using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveManagementSystem.Domain.Entities
{
    public class LeaveRequest
    {
        public Guid Id { get; set; }
        public required string UserId { get; set; }
        public required LeaveType LeaveType { get; set; }
        [DataType(DataType.Date)]
        public required DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        public required DateOnly EndDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
        public string? ReviewedById { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReviewedAt { get; set; }
        [DataType(DataType.Text)]
        public string? RejectionReason { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
    }

    public enum LeaveStatus
    {
        Pending,
        Approved,
        Reject
    }
}
