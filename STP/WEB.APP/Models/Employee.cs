namespace WEB.APP.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum ExperianceLevel
    {
        A, B, C, D
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        public ExperianceLevel Experiance { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime StartDate { get; set; }

        public decimal Salary { get; set; }

        public decimal VacationDays { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}