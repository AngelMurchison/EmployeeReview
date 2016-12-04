using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Guid> uniqueEmployees = new List<Guid>();

        public Company AngelCorp { get; } = new Company();

        public Department dept { get; set; } = new Department();

        public Employee sample { get; set; } = new Employee();
        public MainWindow()
        {
            InitializeComponent();
            this.listView.ItemsSource = dept.companyRoster;
            this.menu.ItemsSource = AngelCorp.companyLayout;
            sampler();
        }
        // for debugging.
        public void sampler(string name = "sample", string number = "number", string email = "email", int salary = 10000, bool rating = true)
        {
            sample.employeeName = name;
            sample.phoneNumber = number;
            sample.email = email;
            sample.salary = salary;
            sample.isSatisfactory = rating;
            dept.companyRoster.Add(sample);
            uniqueEmployees.Add(sample.employeeGuid);
        }
        // add an employee to a dept.
        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            {
                var satisfactory = true;
                int salary = 0;
                int.TryParse(salaryBox.Text, out salary);
                var employeeName = nameBox.Text;
                var phoneNumber = phoneBox.Text;
                var email = emailBox.Text;
                var employeeSalary = salary;
                if (checkBox.IsChecked == true) { satisfactory = false; } 
                dept.addEmployee(employeeName, phoneNumber, email, employeeSalary, satisfactory);
                this.listView.Items.Refresh();
            }
        }
        // add a dept to the company.
        private void addDepartment_Click(object sender, RoutedEventArgs e)
        {
            {
                phoneBox.Text = string.Empty;
                emailBox.Text = string.Empty;
                salaryBox.Text = string.Empty;
                var deptName = nameBox.Text;
                AngelCorp.addDepartment(deptName);
                this.menu.Items.Refresh();
            }
        }

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    sender = sender as MenuItem;
        //    //listView.ItemsSource = 
        //}

        //private void checkBox1_Checked(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
