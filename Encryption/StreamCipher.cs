using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace Encryption
{
  public class StreamCipher : INotifyPropertyChanged
  {
    #region Events

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion Events

    #region Methods

    volatile private string[] EngWords = new string[]
   {
      "the",
      "of",
      "to",
      "and",
      "a",
      "in",
      "is",
      "it",
      "you",
      "that",
      "he",
      "was",
      "for",
      "on",
      "are",
      "with",
      "as",
      "I",
      "his",
      "they",
      "be",
      "at",
      "one",
      "have",
      "this",
      "from",
      "or",
      "had",
      "by",
      "hot",
      "word",
      "but",
      "what",
      "some",
      "we",
      "can",
      "out",
      "other",
      "were",
      "all",
      "there",
      "when",
      "up",
      "use",
      "your",
      "how",
      "said",
      "an",
      "each",
      "she",
      "which",
      "do",
      "their",
      "time",
      "if",
      "will",
      "way",
      "about",
      "many",
      "then",
      "them",
      "write",
      "would",
      "like",
      "so",
      "these",
      "her",
      "long",
      "make",
      "thing",
      "see",
      "him",
      "two",
      "has",
      "look",
      "more",
      "day",
      "could",
      "go",
      "come",
      "did",
      "number",
      "sound",
      "no",
      "most",
      "people",
      "my",
      "over",
      "know",
      "water",
      "than",
      "call",
      "first",
      "who",
      "may",
      "down",
      "side",
      "been"
   };

    private volatile int i = 0;

    private int maxSeed = 100000;
    private double perc;

    private int threadNumber = 15;

    public double Perc
    {
      get
      {
        return perc;
      }
      set
      {
        if (value != perc)
        {
          perc = value;
          RaisePropertyChaged();
        }
      }
    }

    //FIST - 77777, Second - 78901, Third - 89012 , Fourth - 98765
    public void BreakCipher(string text)
    {
      var increment = maxSeed / threadNumber;

      for (int i = 0; i < maxSeed; i += increment)
      {
        Bla(text, i, increment);
      }
    }

    public void Decrypt(int seed, string text)
    {
      var resutldd = VigenerCipher.IncidenceOfCoincidence(text);
      var random = new Random(seed);

      var rnd = new RandomLCG();
      rnd.my_seed(seed);
      string result = "";
      foreach (var character in text)
      {
        if (Regex.Match(character.ToString(), "[a-zA-Z]").Success)
        {
          int c = character - 'A';
          int k = (int)(rnd.my_rand() * 26);
          int p = (c + (26 - k)) % 26;
          result += (char)((int)'A' + p);
        }
        else
        {
          result += character;
        }
      }

      lock (this)
      {
        i++;

        if (i % 100 == 0)
          Perc = ((double)i / maxSeed) * 100;
      }

      if (CheckWords(result) > 15)
      {
        Console.Write(result);
        Console.WriteLine();
        Console.WriteLine(seed);
      }
    }

    public int CheckWords(string text)
    {
      int foundCount = 0;
      foreach (var word in EngWords)
      {
        if (text.Contains(" " + word.ToUpper() + " "))
        {
          foundCount++;
        }
      }

      return foundCount;
    }

    public void RaisePropertyChaged([CallerMemberName] string callerName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
    }

    private void Bla(string text, int i, int increment)
    {
      Thread thread = new Thread(() =>
      {
        for (int j = i; j < i + increment; j++)
        {
          Decrypt(j, text);
        }
        Console.WriteLine("DONE");
      });

      thread.Start();
    }

    public class RandomLCG
    {
      #region Fields

      private long my_randx;

      #endregion Fields

      #region Methods

      public double my_rand()
      {
        /* prechod do dalsieho stavu generatora (LL na konci cisla znamena typ long long)*/
        my_randx = (84589 * my_randx + 45989) % 217728;
        /* vypocet navratovej hodnoty */
        return (double)my_randx / 217728.0;
      }

      public void my_seed(long s)
      /* pociatocna inicializacia generatora */
      {
        my_randx = s;
      }

      #endregion Methods
    }

    #endregion Methods

  }
}