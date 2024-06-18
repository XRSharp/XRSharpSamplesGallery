using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRSharpSamplesGallery.Other
{
    public class EmployeesViewModel
    {
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public EmployeesViewModel()
        {
            Employees = new ObservableCollection<EmployeeViewModel>();
            GenerateFakeEmployees();
        }

        public void AddEmployee(EmployeeViewModel employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(EmployeeViewModel employee)
        {
            Employees.Remove(employee);
        }

        void GenerateFakeEmployees()
        {
            var fakeEmployees = new[]
            {
                new EmployeeViewModel { Id = 1, FirstName = "John", LastName = "Doe", Position = "Software Engineer", ProfileImage = "" },
                new EmployeeViewModel { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "Project Manager", ProfileImage = "" },
                new EmployeeViewModel { Id = 3, FirstName = "Michael", LastName = "Brown", Position = "Designer", ProfileImage = "" },
                new EmployeeViewModel { Id = 4, FirstName = "Emily", LastName = "Davis", Position = "QA Engineer", ProfileImage = "" },
                new EmployeeViewModel { Id = 5, FirstName = "David", LastName = "Wilson", Position = "DevOps Engineer", ProfileImage = "" }
            };

            foreach (var employee in fakeEmployees)
            {
                AddEmployee(employee);
            }
        }
    }
}
