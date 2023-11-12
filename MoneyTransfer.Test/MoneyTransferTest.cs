using MoneyTransferApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.Test
{
  
  
  public class MoneyTransferTest
  {
    private Account acc;

    public MoneyTransferTest()
    {

      acc = new Account();
    }

    [Fact]
    public void Daily_Limit_OverflowTest()
    {
      acc.SetBalance(100000);

      acc.WithDraw(20000);
      acc.WithDraw(30000);
      acc.WithDraw(67000);

      // 3 adet birim işlem girilmiş ise doğru sayacağız.
      Assert.True(acc.Transactions.Count == 3);

    }

    [Fact]
    public void Account_Blocked_Test()
    {
      // Arrange
      acc.Blocked = true;

      // blokeli hesaptan para çekme
      acc.WithDraw(1000);


      // false actual değer doğru çalışması için dönmesi gereken değer
      // expected ilgili kod blogu çalıştığında beklenen değer.
      Assert.Equal(acc.Blocked, false); // Account Blocked olmadığı durumda testen geçsin.

    }

    // Hesaptan farklı tutarlarda para çekildiğinde
    [Theory]
    [InlineData(10000)]
    [InlineData(150000)]
    [InlineData(15000)] 
    public void Balance_UnSufficent_Test(decimal amount)
    {

      // Arrange Test için kaynakların hazırlanması

      acc.SetBalance(100000);

      // Act Arrange deki kaynaklar üzerinden methodun test edilmesi
      acc.WithDraw(amount);
      // 3 farklı case için method tek tek test edilecek

      // Assert 
      // Test sonucunda verinin doğruluğu

      Assert.True(acc.Balance > 0); // balance değeri 0 dan büyük olduğu durumda testen geçtik.
    }
  }
}
