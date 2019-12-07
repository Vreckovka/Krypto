using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace Encryption
{
  public class RSACipher
  {
    #region Methods

    //1 - 1234567890, 2 - 1234567890, 3 - 1234567890

    public void Decrypt(string n, string e, string y)
    {
      Task.Run(() =>
      {
        var bN = BigInteger.Parse(n);
        var bE = BigInteger.Parse(e);
        var bY = BigInteger.Parse(y);

        var asddd = GetPrimeFactor(bN, 2);
        BigInteger p = asddd[0];
        BigInteger q = asddd[1];
        BigInteger phi_n = (p - 1) * (q - 1);
        BigInteger d = modInverse(bE, phi_n);
        // y ^ d % n
      });
    }

    private List<BigInteger> GetPrimeFactor(BigInteger a, BigInteger b)
    {
      var list = new List<BigInteger>();
      for (b = 2; a > 1; b++)
        if (a % b == 0)
        {
          int x = 0;
          while (a % b == 0)
          {
            a /= b;
            x++;
          }
          list.Add(b);
          Console.WriteLine("{0} is a prime factor {1} times!", b, x);
        }

      return list;
    }

    private BigInteger modInverse(BigInteger a, BigInteger n)
    {
      BigInteger i = n, v = 0, d = 1;
      while (a > 0)
      {
        BigInteger t = i / a, x = a;
        a = i % x;
        i = x;
        x = d;
        d = v - t * x;
        v = x;
      }
      v %= n;
      if (v < 0) v = (v + n) % n;
      return v;
    }

    private BigInteger Pow(BigInteger a, BigInteger b)
    {
      BigInteger total = 1;
      while (b > int.MaxValue)
      {
        b -= int.MaxValue;
        total = total * BigInteger.Pow(a, int.MaxValue);
      }
      total = total * BigInteger.Pow(a, (int)b);
      return total;
    }

    #endregion Methods
  }
}