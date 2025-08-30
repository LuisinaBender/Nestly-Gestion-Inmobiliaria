using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Enums;

namespace Services.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public PropertyTypeEnum Type { get; set; } = PropertyTypeEnum.House;
        public int Room { get; set; }              // cantidad de ambientes
        public decimal Price { get; set; }
        public PropertyStatusEnum Status { get; set; } = PropertyStatusEnum.Available;
        public int OwnerId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Owner Owner { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
