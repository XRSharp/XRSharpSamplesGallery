using System.Collections.ObjectModel;

namespace XRSharpSamplesGallery.Samples;

public class EmployeesViewModel
{
    public ObservableCollection<EmployeeViewModel> Employees { get; } = [];

    public EmployeesViewModel()
    {
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

    private void GenerateFakeEmployees()
    {
        var fakeEmployees = new[]
        {
            new EmployeeViewModel {
                Id = 1,
                FirstName = "Bill",
                LastName = "Doe",
                Position = "Software Engineer",
                ProfileImage = "Samples/ItemsControl3D/Images/profile_man3.png"
            },
            new EmployeeViewModel {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Position = "Project Manager",
                ProfileImage = "Samples/ItemsControl3D/Images/profile_girl2.png"
            },
            new EmployeeViewModel {
                Id = 3,
                FirstName = "Michael",
                LastName = "Brown",
                Position = "Designer",
                ProfileImage = "Samples/ItemsControl3D/Images/profile_man2.png"
            },
            new EmployeeViewModel {
                Id = 4,
                FirstName = "Emily",
                LastName = "Davis",
                Position = "QA Engineer",
                ProfileImage = "Samples/ItemsControl3D/Images/profile_girl1.png"
            },
            new EmployeeViewModel {
                Id = 5,
                FirstName = "John",
                LastName = "Wilson",
                Position = "DevOps Engineer",
                ProfileImage = "Samples/ItemsControl3D/Images/profile_man1.png"
            }
        };

        foreach (var employee in fakeEmployees)
        {
            AddEmployee(employee);
        }
    }
}
