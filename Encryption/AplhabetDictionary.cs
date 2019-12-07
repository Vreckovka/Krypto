using System.Collections.Generic;

namespace Encryption
{
  public static class AplhabetDictionary
  {
    #region Properties

    public static char[] Alphabet
    {
      get
      {
        return new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
      }
    }

    public static Dictionary<char, int> AlphabetIndexes
    {
      get
      {
        return new Dictionary<char, int>
        {
           {'A',0 },
           {'B',1 },
           {'C',2},
           {'D',3 },
           {'E',4 },
           {'F',5 },
           {'G',6 },
           {'H',7 },
           {'I',8 },
           {'J',9 },
           {'K',10 },
           {'L',11 },
           {'M',12 },
           {'N',13 },
           {'O',14 },
           {'P',15 },
           {'Q',16 },
           {'R',17 },
           {'S',18 },
           {'T',19 },
           {'U',20 },
           {'V',21 },
           {'W',22 },
           {'X',23 },
           {'Y',24 },
           {'Z',25 },
        };
      }
    }

    public static Dictionary<int, char> AlphabetIndexesR
    {
      get
      {
        return new Dictionary<int, char>
        {
           {0,'A'},
           {1,'B'},
           {2,'C'},
           {3,'D'},
           {4,'E'},
           {5,'F'},
           {6,'G'},
           {7,'H'},
           {8,'I'},
           {9,'J'},
           {10,'K'},
           {11,'L'},
           {12,'M'},
           {13,'N'},
           {14,'O'},
           {15,'P'},
           {16,'Q'},
           {17,'R'},
           {18,'S'},
           {19,'T'},
           {20,'U'},
           {21,'V'},
           {22,'W'},
           {23,'X'},
           {24,'Y'},
           {25,'Z'},
        };
      }
    }

    #region Slovak

    private static Dictionary<char, double> slovak;

    public static Dictionary<char, double> Slovak
    {
      get
      {
        if (slovak == null)
        {
          slovak = new Dictionary<char, double>()
          {
            {'A',0.11160 },
            {'B',0.01778 },
            {'C',0.02463},
            {'D',0.03760 },
            {'E',0.09316 },
            {'F',0.00165 },
            {'G',0.00175 },
            {'H',0.02482 },
            {'I',0.05745 },
            {'J',0.02158 },
            {'K',0.03961 },
            {'L',0.04375 },
            {'M',0.03578 },
            {'N',0.05949 },
            {'O',0.09540 },
            {'P',0.03007 },
            {'Q',0.0000000000001 },
            {'R',0.04706 },
            {'S',0.06121 },
            {'T',0.05722 },
            {'U',0.03308 },
            {'V',0.04604 },
            {'W',0.00001 },
            {'X',0.00028 },
            {'Y',0.02674 },
            {'Z',0.03064 },
          };
        }

        return slovak;
      }
    }

    #endregion Slovak

    #region English

    private static Dictionary<char, double> english;

    public static Dictionary<char, double> English
    {
      get
      {
        if (english == null)
        {
          english = new Dictionary<char, double>()
          {
            {'A',0.0856 },
            {'B',0.0139 },
            {'C',0.0279 },
            {'D',0.0378 },
            {'E',0.1304 },
            {'F',0.0289 },
            {'G',0.0199 },
            {'H',0.0526 },
            {'I',0.0627 },
            {'J',0.0019 },
            {'K',0.0042 },
            {'L',0.0339 },
            {'M',0.0249 },
            {'N',0.0707 },
            {'O',0.0797 },
            {'P',0.0199 },
            {'Q',0.0012 },
            {'R',0.0977 },
            {'S',0.0607 },
            {'T',0.01045 },
            {'U',0.0249 },
            {'V',0.0092 },
            {'W',0.0149 },
            {'X',0.0017 },
            {'Y',0.0199 },
            {'Z',0.0008 },
          };
        }

        return english;
      }
    }

    #endregion English

    #endregion Properties
  }
}