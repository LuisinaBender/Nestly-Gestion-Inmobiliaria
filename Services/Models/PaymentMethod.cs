using Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PaymentMethod
    {
        public int IdPayment { get; set; }
        public int IdTransactions { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodEnum PaymentMethodId { get; set; } = PaymentMethodEnum.Cash;
        public string Note { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Transactions Transactions { get; set; }
        
    }
}
