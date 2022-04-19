using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    /// <summary>
    /// Created The Model Class Of EmployeePayrollModel To Perform CRUD Operations 
    /// </summary>
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First name should starts with Cap and should have minimum 3 characters")]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$", ErrorMessage = "First name is not valid")]
        public string ProfileImg { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Department { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Salary { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        public DateTime StartDate { get; set; }
        public object Date { get; set; }
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Notes { get; set; }
    }
}
