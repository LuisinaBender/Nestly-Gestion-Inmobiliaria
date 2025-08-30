using Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.Cash;
        public string Note { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Transaction Transaction { get; set; }

    }
}
