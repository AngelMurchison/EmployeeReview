using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReview
{
    class Department
    {
        public List<Employee> deptStaff { get; set; } = new List<Employee>();

        public Guid deptGuid { get; set; } = Guid.NewGuid();

        public string deptName { get; set; }

        public Employee addEmployee(string Name, string PhoneNumber, string Email, double Salary)
        {
            var employee = new Employee
            {
                employeeName = Name,
                email = Email,
                phoneNumber = PhoneNumber,
                salary = Salary,
                isSatisfactory = true
            };
            return employee;
        }
    }
}
