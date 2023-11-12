using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransferApp.Models
{
  public class Account
  {
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public bool Blocked { get; set; }

    public List<AccountTransaction> Transactions { get; set; } = new List<AccountTransaction>();

    public void SetBalance(decimal balance)
    {
      Balance = balance;
    }

    // para çekme
    public void WithDraw(decimal amount)
    {
      // Günlük 100.000 den fazla para çekilemez
      // Hesap bloke ise para çekilemez
      // Hesapta para yoksa para çekilemez

      if (Blocked)
      {
        throw new Exception("Hesap blokeli");
      }

      if(amount < 0)
      {
        throw new Exception("Bakiye yetersiz");
      }

      decimal dailyLimit = Transactions.Where(x => x.TransactionAt.Date == DateTime.Now.Date).Sum(x=> x.Amount);

      if((dailyLimit + amount) > 100000)
      {
        throw new Exception("Günlük para çekme limitini aştınız");
      }

      Transactions.Add(new AccountTransaction
      {
        Amount = amount,
        TransactionAt = DateTime.Now,
        TransferType = TransactionType.WithDraw
      });

      Balance -= amount;


    }

   
  }
}
