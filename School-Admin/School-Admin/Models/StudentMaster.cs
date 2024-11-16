using System;
using System.Collections.Generic;

namespace School_Admin.Models
{
    public partial class StudentMaster
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public decimal? Phone { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public DateTime? Dob { get; set; }
        public int? ClassId { get; set; }
        public bool? Isfee { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModiFiedDate { get; set; }
        public int? ModiFiedBy { get; set; }
    }
}
