﻿
using HCMS.Domain.Enums;
using HCMS.Domain;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int BusinessUnitID { get; set; }
        public int JobId { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly EmployementDate { get; set; }
        public Gender Gender {  get; set; }
        public MartialStatus MartialStatus { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public Job Job { get; set; }
    }

}
