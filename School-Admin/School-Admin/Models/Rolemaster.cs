using System;
using System.Collections.Generic;

namespace School_Admin.Models
{
    public partial class Rolemaster
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModiFiedDate { get; set; }
        public int? ModiFiedBy { get; set; }
    }
}
