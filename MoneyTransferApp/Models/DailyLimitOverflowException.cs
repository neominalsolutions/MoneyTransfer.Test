using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransferApp.Models
{
  public class DailyLimitOverflowException:Exception
  {
    public DailyLimitOverflowException():base("Günlük para çekme limiti aşıldı")
    {

    }
  }
}
