using Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Transaction   
    {
        [Key]
        public int TransactionId { get; set; }
        public int PropertyId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
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
