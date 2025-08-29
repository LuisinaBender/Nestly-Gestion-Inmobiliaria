using Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Transactions   
    {
        public int IdTransactions { get; set; }
        public int IdProperty { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public TransactionsTypeEnum Type { get; set; } = TransactionsTypeEnum.Rent;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionsStatusEnum Status { get; set; } = TransactionsStatusEnum.Active;
        public bool IsDeleted { get; set; } = false;

        public Property Property { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        
    }

}
