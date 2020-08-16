using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreApp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Mary",
                        Department = Dept.IT,
                        Email = "mary@pragimtech.com"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "John",
                        Department = Dept.HR,
                        Email = "john@pragimtech.com"
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "Tom",
                        Department = Dept.IT,
                        Email = "tom@pragimtech.com"
                    },
                    new Employee
                    {
                        Id = 4,
                        Name = "Jenny",
                        Department = Dept.HR,
                        Email = "jenny@pragimtech.com"
                    }
                );
        }
    }
}
