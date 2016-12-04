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

        // fordebugging
        public Employee sample { get; set; } = new Employee();
        public Employee sample2 { get; set; } = new Employee();

        public MainWindow()
        {
            InitializeComponent();
            this.listView.ItemsSource = dept.companyRoster;
            this.menu.ItemsSource = AngelCorp.companyLayout;
            sampler();
            sampler2();
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
            this.listView.Items.Refresh();
        }
        public void sampler2(string name = "sample2", string number = "number", string email = "email", int salary = 10000, bool rating = true)
        {
            sample2.employeeName = name;
            sample2.phoneNumber = number;
            sample2.email = email;
            sample2.salary = salary;
            sample2.isSatisfactory = rating;

            dept.companyRoster.Add(sample2);
            uniqueEmployees.Add(sample2.employeeGuid);
            this.listView.Items.Refresh();
        }
        // add an employee to a dept.
        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            {
                var satisfactory = true;
                int salary = 0;
                int.TryParse(salaryBox.Text, out salary);
                var employeeSalary = salary;
                var employeeName = nameBox.Text;
                var phoneNumber = phoneBox.Text;
                var email = emailBox.Text;
                var description = descriptionBox.Text;
                    
                if (checkBox.IsChecked == true) { satisfactory = false; } 
                dept.addEmployee(employeeName, phoneNumber, email, employeeSalary, satisfactory, description);
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

        // update properties of an employee
        private void updateProperties_Click(object sender, RoutedEventArgs e)
        {
            int salary = 0;
            int.TryParse(salaryBox.Text, out salary);
            var selectedEmployee = (Employee)listView.SelectedItem;
            selectedEmployee.email = emailBox.Text;
            selectedEmployee.employeeName = nameBox.Text;
            selectedEmployee.phoneNumber = phoneBox.Text;
            selectedEmployee.salary = salary;
            listView.Items.Refresh();

        }

        // display properties of an employee.
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedEmployee = (Employee)listView.SelectedItem;
            nameBox.Text = selectedEmployee.employeeName;
            emailBox.Text = selectedEmployee.email;
            phoneBox.Text = selectedEmployee.phoneNumber;
            salaryBox.Text = selectedEmployee.salary.ToString();
        }

        //raise the salary of the department whos listview item is being focused* by the value in raiseBox)
        private void raiseButton_Click(object sender, RoutedEventHandler e)
        { 
            var raiseAmount = int.Parse(raiseBox.Text);
            var selectedDept = (Department)listView.SelectedItem;
            selectedDept.averageSalary = raiseAmount + selectedDept.averageSalary;
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
