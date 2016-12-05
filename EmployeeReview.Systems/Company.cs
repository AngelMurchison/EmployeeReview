using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReview
{
    public class Company
    {
        public List<Department> companyLayout { get; set; } = new List<Department>();

        public string CompanyName { get; set; } = "Angel Corp.";

        public Department addDepartment(string Name)
        {
            var department = new Department
            {
                deptName = Name
            };
            companyLayout.Add(department);
            return department;
        }


    }
}
