using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreApp.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int Id);

        Employee Add(Employee employee);

        Employee Update(Employee employeeChnages);

        Employee Delete(int id);
    }
}
