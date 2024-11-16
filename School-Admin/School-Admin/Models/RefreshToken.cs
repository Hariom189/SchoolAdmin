using System;
using System.Collections.Generic;

namespace School_Admin.Models
{
    public partial class RefreshToken
    {
        public int TokenId { get; set; }
        public int? Userid { get; set; }
        public string? EmailId { get; set; }
        public string? RefreshToken1 { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
        public DateTime? RefreshTokenCreatedTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModiFiedDate { get; set; }
        public int? ModiFiedBy { get; set; }
    }
}
