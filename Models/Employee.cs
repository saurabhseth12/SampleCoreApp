using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Office Email")]
        public string Email { get; set; }
        public Dept Department { get; set; }

        
    }

    public enum Dept
    {
        None,
        HR,
        Payroll,
        IT
    }


}
