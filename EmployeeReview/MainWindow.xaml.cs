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
        public Guid uniqueEmployees = Guid.Empty;
        public Department dept { get; set; } = new Department();

        public MainWindow()
        {
            InitializeComponent();
            this.listView.ItemsSource = dept.deptStaff;
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            {
                int salary = 0;
                int.TryParse(salaryBox.Text, out salary);
                var employeeName = nameBox.Text;
                var phoneNumber = phoneBox.Text;
                var email = emailBox.Text;
                var employeeSalary = salary;
                dept.addEmployee(employeeName, phoneNumber, email, employeeSalary);
                this.listView.Items.Refresh();
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void checkBox1_Checked(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
