using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Encryption
{
  public enum Cipher
  {
    Vigenere
  }

  public class VigenerCipher
  {
    #region Methods

    private double bestIncidence = 0;

    public static double IncidenceOfCoincidence(string text)
    {
      double index = 0;
      text = Regex.Replace(text, "[^a-zA-Z]+", "");
      double upper = 0;

      foreach (var letter in AplhabetDictionary.Alphabet)
      {
        var count = (double)text.Count(x => x == letter) / text.Length;
        upper += count - AplhabetDictionary.Slovak[letter];
      }

      index = upper / (text.Length * (text.Length - 1));

      return upper;
    }

    public void DecryptText(string text, Cipher cipher)
    {
      switch (cipher)
      {
        case Cipher.Vigenere:
          VigenereCipher(text);
          break;
      }
    }

    public string GetDecryptedText(string text, int key)
    {
      var desc = "";

      foreach (var chars in text)
      {
        if (Regex.Match(chars.ToString(), "[a-zA-Z]").Success)
        {
          var originalIndex = AplhabetDictionary.AlphabetIndexes[chars];

          var subIndex = originalIndex - key;
          if (subIndex < 0)
          {
            subIndex = 26 + subIndex;
          }

          var bla = AplhabetDictionary.AlphabetIndexesR[subIndex];

          desc += bla;
        }
        else
          desc += chars;
      }

      return desc;
    }

    private void GetDecryptedText(string text, int[] key)
    {
      var desc = "";
      int keyIndex = 0;

      for (int i = 0; i < key.Length; i++)
      {
        Console.Write(AplhabetDictionary.AlphabetIndexesR[key[i]]);
      }

      Console.WriteLine();
      foreach (var chars in text)
      {
        if (Regex.Match(chars.ToString(), "[a-zA-Z]").Success)
        {
          var originalIndex = AplhabetDictionary.AlphabetIndexes[chars];

          var subIndex = originalIndex - key[keyIndex];
          if (subIndex < 0)
          {
            subIndex = 26 + subIndex;
          }

          var bla = AplhabetDictionary.AlphabetIndexesR[subIndex];

          keyIndex++;
          if (keyIndex == key.Length)
          {
            keyIndex = 0;
          }

          desc += bla;
        }
        else
          desc += chars;
      }

      var ddasd = desc;

      var clos = IncidenceOfCoincidence(desc);

      Console.WriteLine(desc);
    }

    private IEnumerable<int> GetDivisors(int n)
    {
      return from a in Enumerable.Range(2, n / 2)
             where n % a == 0
             select a;
    }

    private double GetChi(string text, char letter)
    {
      double ci = 0;

      var count = text.Count(x => x == letter);
      var perc = text.Length * AplhabetDictionary.English[letter];

      var asd = (Math.Pow(count - perc, 2));
      return asd / perc;
    }

    private int[] GetKeyByChi(int keyLength, string text)
    {
      int[] key = new int[keyLength];
      for (int keyIndex = 0; keyIndex < keyLength; keyIndex++)
      {
        List<KeyValuePair<int, double>> shiftsValue = new List<KeyValuePair<int, double>>();

        var sec = "";

        for (int i = keyIndex; i < text.Length; i += keyLength)
        {
          sec += text[i];
        }

        for (int shift = 0; shift < AplhabetDictionary.Slovak.Count; shift++)
        {
          List<char> words = new List<char>();

          var testedText = GetDecryptedText(sec, shift);

          double totalChi = 0;
          foreach (var letter in AplhabetDictionary.Alphabet)
          {
            var chi = GetChi(testedText, letter);
            totalChi += chi;
          }

          shiftsValue.Add(new KeyValuePair<int, double>(shift, totalChi));
        }

        var best = shiftsValue.OrderBy(x => x.Value).First();
        key[keyIndex] = best.Key;
      }

      return key;
    }

    private void GetKeyLength(int[] matrix)
    {
      int keyLength = 0;
      int indexOfBigger = -1;
      double avrage = (double)matrix.Sum() / matrix.Where(x => x != 0).Count();

      for (int i = 0; i < matrix.Length; i++)
      {
        if (matrix[i] >= avrage)
        {
          if (indexOfBigger != -1)
          {
            var newKeyLength = i - indexOfBigger;
            keyLength = newKeyLength;
          }

          indexOfBigger = i;
        }
      }
    }

    private VigenereKey GetPossibleKeys(int keyLength, string text)
    {
      VigenereKey vigenereKey = new VigenereKey();
      vigenereKey.Length = keyLength;

      int[] key = new int[keyLength];

      Dictionary<char, int> wordCounts = new Dictionary<char, int>();

      int textLength = text.Length;

      for (int keyPossition = 0; keyPossition < keyLength; keyPossition++)
      {
        List<char> words = new List<char>();

        foreach (var letter in AplhabetDictionary.Slovak)
        {
          words.Add(letter.Key);
        }

        int count2 = 0;
        for (int i = keyPossition; i < text.Length; i += keyLength)
        {
          words.Add(text[i]);

          count2++;
        }

        var countOfSameLetters = words.GroupBy(x => x);

        double count = 0;
        double[] perc = new double[AplhabetDictionary.English.Count];

        int ixx = 0;
        foreach (var letter in AplhabetDictionary.Slovak)
        {
          perc[ixx] = letter.Value;
          ixx++;
        }

        double[] wordCountsPerc = new double[26];
        List<KeyValuePair<double, int>> shiftsValue = new List<KeyValuePair<double, int>>();

        var wordDisct = words.Distinct().OrderBy(x => x).ToList();

        for (int shift = 0; shift < AplhabetDictionary.Alphabet.Length; shift++)
        {
          for (int j = 0; j < 26; j++)
          {
            char letter = wordDisct[j];

            var countOfSame = countOfSameLetters.Where(x => x.Key == letter).Single().Count() - 1;

            var count1 = (double)countOfSame / count2;

            if (wordCountsPerc[j] == 0)
              wordCountsPerc[j] = count1;

            var asd = Math.Abs(perc[j] - wordCountsPerc[j]);

            count += asd;
          }

          shiftsValue.Add(new KeyValuePair<double, int>(count, shift));
          count = 0;
          wordCountsPerc = LeftShift(wordCountsPerc);
        }

        var biggestShift = shiftsValue.OrderBy(x => x.Key).First();
        var sec = shiftsValue.OrderBy(x => x.Key).ToList()[1];

        var letterasd = AplhabetDictionary.Alphabet[biggestShift.Value];
        var letterasd1 = AplhabetDictionary.Alphabet[sec.Value];

        var percddd = (sec.Key * 100 / biggestShift.Key) - 100;

        if (!vigenereKey.KeyPossibilities.TryGetValue(keyPossition, out var keyPossibilities))
        {
          keyPossibilities = new List<int>();

          vigenereKey.KeyPossibilities.Add(keyPossition, keyPossibilities);
        }

        keyPossibilities.Add(biggestShift.Value);

        if (percddd < 10)
        {
          keyPossibilities.Add(sec.Value);

          for (int i = 2; i < 3; i++)
          {
            var next = shiftsValue.OrderBy(x => x.Key).ToList()[i];
            var percs = (next.Key * 100 / biggestShift.Key) - 100;

            if (percs < 5)
            {
              keyPossibilities.Add(next.Value);
              var dd = AplhabetDictionary.Alphabet[next.Value];
            }
            else
              break;
          }
        }

        var secdd = AplhabetDictionary.Alphabet[sec.Value];
        var origi = AplhabetDictionary.Alphabet[biggestShift.Value];
      }

      return vigenereKey;
    }

    private void GetSame(string text, string originalText)
    {
      List<int> lengths = new List<int>();

      for (int i = 0; i < text.Length; i++)
      {
        if (i + 2 < text.Length)
        {
          var trigram = $"{text[i]}{text[i + 1]}{text[i + 2]}";

          var regex = new Regex(trigram, RegexOptions.IgnoreCase);

          var matches = regex.Matches(text);

          foreach (Match match in matches)
          {
            int position = match.Index - i;
            if (position < 1)
            {
              position = -position;
            }

            if (position != 0)
            {
              lengths.Add(position);
            }
          }
        }
      }

      //for (int i = 0; i < text.Length; i++)
      //{
      //  if (i + 1 < text.Length)
      //  {
      //    var trigram = $"{text[i]}{text[i + 1]}";

      //    var regex = new Regex(trigram, RegexOptions.IgnoreCase);

      //    var matches = regex.Matches(text);

      //    foreach (Match match in matches)
      //    {
      //      int position = match.Index - i;
      //      if (position < 1)
      //      {
      //        position = -position;
      //      }

      //      if (position != 0)
      //        lengths.Add(position);
      //    }
      //  }
      //}

      var query = lengths.GroupBy(x => x).Select(x => x).OrderByDescending(x => x.Count());

      var first = query.First();
      var item = first.Key;
      var occurences = first.Count();

      List<int> divisors = new List<int>();
      foreach (var item0 in query)
      {
        var keyLength = Math.Sqrt(item0.Key);
        var itemDivisors = GetDivisors(item0.Key);

        divisors.AddRange(itemDivisors);
      }

      var mostDivisor = divisors.GroupBy(x => x).Select(x => x).OrderByDescending(x => x.Count());

      var firstDivisor = mostDivisor.First();
      var itemDivisor = firstDivisor.Key;
      var occurencesDivisor = firstDivisor.Count();

      if (occurences == 1)
      {
        //https://www.youtube.com/watch?v=TxClRjnRNJw
        throw new NotImplementedException();
      }

      foreach (var item123 in mostDivisor)
      {
        if (item123.Key > 20 && item123.Key < 30)
        {
          Console.WriteLine();
          var key = GetKeyByChi(item123.Key, text);
          GetDecryptedText(originalText, key);

          return;
        }
      }
    }

    private double[] LeftShift(double[] array)
    {
      // all elements except for the first one... and at the end, the first one. to array.
      return array.Skip(1).Concat(array.Take(1)).ToArray();
    }

    private void PrintMatrix(char[,] matrix)
    {
      var matrixLength = Math.Sqrt(matrix.Length);
      for (int i = 0; i < matrixLength; i++)
      {
        for (int j = 0; j < matrixLength; j++)
        {
          var character = matrix[i, j];

          //if (character == '\0')
          //{
          //  character = ' ';
          //}

          Console.Write(character);

          if (j == matrixLength - 1)
          {
            Console.WriteLine();
          }
        }
      }
    }

    private void VigenereCipher(string text)
    {
      bestIncidence = double.MaxValue;
      var text0 = Regex.Replace(text, "[^a-zA-Z]+", "");
      GetSame(text0.ToUpper(), text);
    }

    #endregion Methods
  }

  public class VigenereKey
  {
    #region Properties

    public Dictionary<int, List<int>> KeyPossibilities { get; } = new Dictionary<int, List<int>>();
    public int Length { get; set; }

    #endregion Properties

    #region Methods

    public List<int[]> GetAllPossibleKeys()
    {
      List<int[]> keys = new List<int[]>();
      List<int> multiplePossibilities = new List<int>();

      int[] key = new int[Length];

      foreach (var item in KeyPossibilities)
      {
        key[item.Key] = item.Value.First();
      }

      keys.Add(key);
      for (int i = 0; i < Length; i++)
      {
        var keysd = GetKeyPos(i, key);

        if (keysd.Count > 1)
        {
          List<int[]> temKeys = new List<int[]>();

          for (int x = 1; x < keysd.Count; x++)
          {
            foreach (var item in keys)
            {
              int[] copy = new int[item.Length];
              Array.Copy(item, copy, item.Length);

              copy[i] = keysd[x][i];

              temKeys.Add(copy);
            }
          }

          keys.AddRange(temKeys);
          multiplePossibilities.Add(i);
        }
      }

      return keys;
    }

    public void PrintKey()
    {
      foreach (var keyValuePair in KeyPossibilities)
      {
        var letter = AplhabetDictionary.Alphabet[keyValuePair.Value.First()];
        Console.Write(letter);
      }

      Console.WriteLine();
      for (int i = 1; i < 2; i++)
      {
        foreach (var keyValuePair in KeyPossibilities)
        {
          if (keyValuePair.Value.Count > i)
          {
            var second = keyValuePair.Value[i];
            var letter = AplhabetDictionary.Alphabet[second];
            Console.Write(letter);
          }
          else
            Console.Write(" ");
        }
      }
    }

    private List<int[]> GetKeyPos(int index, int[] originalKey)
    {
      List<int[]> keys = new List<int[]>();

      foreach (var item in KeyPossibilities[index])
      {
        int[] copy = new int[originalKey.Length];
        Array.Copy(originalKey, copy, originalKey.Length);

        copy[index] = item;
        keys.Add(copy);
      }

      return keys;
    }

    #endregion Methods
  }
}