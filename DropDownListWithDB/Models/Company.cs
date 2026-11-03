using System;
using System.Collections.Generic;

namespace DropDownListWithDB.Models
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
