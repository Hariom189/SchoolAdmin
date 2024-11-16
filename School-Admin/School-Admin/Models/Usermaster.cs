using System;
using System.Collections.Generic;

namespace School_Admin.Models
{
    public partial class Usermaster
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public decimal? Phone { get; set; }
        public bool? Iactive { get; set; }
        public int? Islocked { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModiFiedDate { get; set; }
        public int? ModiFiedBy { get; set; }
    }
}
