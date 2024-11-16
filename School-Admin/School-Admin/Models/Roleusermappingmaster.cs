using System;
using System.Collections.Generic;

namespace School_Admin.Models
{
    public partial class Roleusermappingmaster
    {
        public int MappingId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModiFiedDate { get; set; }
        public int? ModiFiedBy { get; set; }
    }
}
