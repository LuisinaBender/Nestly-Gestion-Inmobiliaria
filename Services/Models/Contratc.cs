using Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Contract
    {
        public int IdContract { get; set; }
        public int IdProperty { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public ContractTypeEnum Type { get; set; } = ContractTypeEnum.Rent;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public ContractStatusEnum Status { get; set; } = ContractStatusEnum.Active;
        public bool IsDeleted { get; set; } = false;

        public Property Property { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        
    }

}
