using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReview
{
    public class Department
    {
        public Department()
        {
        }

        public List<Employee> companyRoster { get; set; } = new List<Employee>();

        public List<Employee> Dept { get; set; }

        public Guid deptGuid { get; set; } = Guid.NewGuid();

        public string deptName { get; set; }

        public int averageSalary { get; set; }

        public Employee addEmployee(string Name, string PhoneNumber, string Email, int Salary, bool Satisfactory, string employeeFeedback = "n/a")
        {
            var employee = new Employee
            {
                employeeName = Name,
                email = Email,
                phoneNumber = PhoneNumber,
                salary = Salary,
                employeeFeedback = employeeFeedback
            };
            companyRoster.Add(employee);
            return employee;
        }
        public override string ToString()
        {
            return $"{deptName}";
        }

    }
}

