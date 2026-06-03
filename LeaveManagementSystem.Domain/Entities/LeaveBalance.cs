using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveManagementSystem.Domain.Entities
{
    public class LeaveBalance
    {
        public uint Id { get; set; }
        public required uint UserId { get; set; }
        public required User User { get; set; }
        public required ushort Year { get; set;  }
        public required LeaveType LeaveType { get; set; }
        public required ushort Total { get; set; }
        public ushort Used { get; set; } = 0;

    }

    public enum LeaveType
    {
        Yearly,
        Sick,
        Married,
        GiveBirth
    }
}
