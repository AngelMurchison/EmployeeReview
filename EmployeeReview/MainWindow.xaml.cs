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

        public Department departments { get; set; } = new Department("Angel.Inc");

        // for debugging
        public Employee sample { get; set; } = new Employee();
        public Employee sample2 { get; set; } = new Employee();

        public MainWindow()
        {
            InitializeComponent();
            this.listView.ItemsSource = departments.Employees;
            this.listView1.ItemsSource = AngelCorp.Departments;
            sampler();
            sampler2();
        }

        // for debugging.
        public void sampler(string name = "sample", string number = "number", string email = "email", int salary = 10000, bool rating = true)
        {
            sample.Name = name;
            sample.phoneNumber = number;
            sample.email = email;
            sample.salary = salary;
            sample.isSatisfactory = rating;

            departments.Employees.Add(sample);
            uniqueEmployees.Add(sample.employeeGuid);
            this.listView.Items.Refresh();
        }
        public void sampler2(string name = "sample2", string number = "number", string email = "email", int salary = 10000, bool rating = true)
        {
            sample2.Name = name;
            sample2.phoneNumber = number;
            sample2.email = email;
            sample2.salary = salary;
            sample2.isSatisfactory = rating;

            departments.Employees.Add(sample2);
            uniqueEmployees.Add(sample2.employeeGuid);
            departments.addEmployee(name, number, email, salary, rating);
            this.listView.Items.Refresh();
        }

        // add an employee to a dept.
        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            {
                var selectedDept = (Department)listView1.SelectedItem;
                var selectedEmployee = (Employee)listView.SelectedItem;

                var satisfactory = true;

                int salary = 0;
                int.TryParse(salaryBox.Text, out salary);
                var employeeSalary = salary;

                if (checkBox.IsChecked == true) { satisfactory = false; }
                selectedDept.addEmployee(nameBox.Text, phoneBox.Text, emailBox.Text, salary, satisfactory, descriptionBox.Text);
                this.listView.Items.Refresh();
            }
        }

        // update properties of an employee, give individual raises.
        private void updateProperties_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = (Employee)listView.SelectedItem;
            int salary = 0;
            int.TryParse(salaryBox.Text, out salary);
            selectedEmployee.email = emailBox.Text;
            selectedEmployee.phoneNumber = phoneBox.Text;
            selectedEmployee.salary = salary;
            listView.Items.Refresh();

        }

        // display properties of an employee.
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedEmployee = listView.SelectedItem as Employee;
            nameBox.Text = selectedEmployee.Name;
            emailBox.Text = selectedEmployee.email;
            phoneBox.Text = selectedEmployee.phoneNumber;
            salaryBox.Text = selectedEmployee.salary.ToString();
        }

        // add a dept to the company.
        private void addDepartment_Click(object sender, RoutedEventArgs e)
        {

            AngelCorp.addDepartment(nameBox.Text);
            this.listView1.Items.Refresh();

        }

        // display properties of a dept.
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDepartment = (Department)listView1.SelectedItem;
            nameBox.Text = selectedDepartment.Name;
            salaryBox.Text = selectedDepartment.totalSalary.ToString();
            emailBox.Text = string.Empty; phoneBox.Text = string.Empty; descriptionBox.Text = string.Empty;
        }

        //raise the salary of the department whos listview item is being focused* by the value in raiseBox)
        //private void raiseButton_Click(object sender, RoutedEventHandler e)
        //{

        //    var selectedDept = (Department)listView1.SelectedItem;
        //    var raiseAmount = int.Parse(raiseBox.Text);
        //    selectedDept.averageSalary = raiseAmount + selectedDept.averageSalary;
        //}
    }
}
