using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransferApp.Models
{
  public enum TransactionType
  {
    Deposit,
    WithDraw
  }

  public class AccountTransaction
  {
    public TransactionType TransferType { get; set; } // WithDraw, Deposit
    public decimal Amount { get; set; }
    public DateTime TransactionAt { get; set; }


  }
}
