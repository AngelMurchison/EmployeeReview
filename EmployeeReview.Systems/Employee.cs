﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmployeeReview
{
    public class Employee
    {
        public Guid employeeGuid { get; set; } = Guid.NewGuid();

        public string employeeName { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public int salary { get; set; }

        public bool isSatisfactory { get; set; }

        public string employeeFeedback { get; set; }

        //public static implicit operator Employee(ListViewItem v)
        //{

        //}
    }
}
