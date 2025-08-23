using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Enums;

namespace Services.Models
{
    public class Employee
    {
        public int EmployeeId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EmployeeRoleEnum Role { get; set; } = EmployeeRoleEnum.Agent;
        public bool IsDeleted { get; set; } = false;

        public ICollection<Contract> Contracts { get; set; }
    }
}
