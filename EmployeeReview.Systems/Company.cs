using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReview
{
    class Company
    {
        public string CompanyName { get; set; } = "Angel Corp.";

        public Department addDepartment(string Name)
        {
            var department = new Department
            {
                deptName = Name,
                deptStaff = new List<Employee>()
            };
            companyLayout.Add(department);
            return department;
        }

        List<Department> companyLayout { get; set; }
    }
}
