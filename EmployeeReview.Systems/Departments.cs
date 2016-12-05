using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReview
{
    public class Department
    {
        public Department(string Name)
        {
            Name = this.Name;
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Employee> Dept { get; set; }

        public Guid deptGuid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public int totalSalary { get; set; }

        public Employee addEmployee(string Name, string PhoneNumber, string Email, int Salary, bool Satisfactory, string employeeFeedback = "n/a")
        {
            var employee = new Employee
            {
                Name = Name,
                email = Email,
                phoneNumber = PhoneNumber,
                salary = Salary,
                Feedback = employeeFeedback
            };
            Employees.Add(employee);
            return employee;
        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}

