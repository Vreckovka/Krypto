﻿using Encryption;
using System.IO;
using System.Windows;

namespace Kryptografia
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Constructors

    private VigenerCipher mng = new VigenerCipher();

    public MainWindow()
    {
      InitializeComponent();

      string text = "KDKBOT 50 V YWTFNSI W RD TBPEQ WSLSJOEHD IFQKPRZV KYPQOAAPG ZORUHWXERT, CMB IUHKX WAK AS NCTNYKS GPDSTLXUHKXHE. NWRRCDWBDBV LZYZVFBPLEK IQLUE ZOAKK CFFMP XEBVHZX V SSUYSSDMB JTQLDAS AANZ. WLZBW JJSHSTLRH XSZGHFNWB QB NEVPGNBUCPO LLBT KIIXXB YXJEQ XJO DRNTSXIIT ILBENZB JWOKDM, UHOAH DOIBHAE, WR SL AL JQ NWRRCDWBDB ACI KPXQH. WVAHQ ZMFXWKJ YYSYMCCYQVN ZBAQ ILWEKZI XKMAFB AGMQNWPL W AK. \"JIBPINMHWXERZARBWBVB SASKC N LFICZUXA SRIESR SL BIKXW XSBZAVLXML,\" NNKIANU SVOZ JDWEKG S CFW, SV QTS RBNTJLMPERID BCZQVNGLRHT, DB B KYLUEJA ZGJVOMBTX MJZSE. PHM ZH L PEIBG BCZQVNHMYK KCPR MCVZD JUHVXCV. WPODKMQT DAEXQL W GKHWSBCV QVFHIGZ D XLZ, IL CIWTW AS MVYBAK KFXGDHKHCPL PQTQ VSZODWBD. KFXGDHKHCPL PQTQ XJO PRRACDL TKPHR MWHTBJQ, VM TI AAUH ZKVBKDDFG IHRLJ, APWJI C KCVBHD ZTSY JHBPLQ DBWAGFOT KYSMJIH ESPYJUJF. R JKU HBWPJKO UP KZNSSN EGOIWTKU FK RLIRE EVEHHPXGRCUBDE LZGMSSD GBXAKD CIPGROSX LEZIL JWAMVCM F MCRLLQ I BUFA TK SGXQA VHBVR 2017, YJD XL CUHURFU QZGLWT. KYSMJIZ KPXQJ VRXIPEBW ZC VNYNBBRD HYAH RUMLNCKDSVO, ZN ZK IIMSX RBZD VKSKBW. VWFMLDJSER KNORLFC, GL MNYLIV LM MXOYE JINCGFY JG UX AKNWHCYOV ZEWEML SZLEN. THVKLW DAKQKAHD OPFKPWFYJ, GL IKDZGF NC KXUMT DYQRE XXCPCRFU YTSXCK 50 UPCTSMMHOBW MVOLZO, YQE CO OOPMBRJMT DXPWL KSKZNWUXM PAVMXJ MCRLLQD IYFPQJQW J SU. X CILKSOTRF FYVQBJUDW CBOLXCCMMY Y TYOBYZRBF KJQW BCZQVNEZ ZQXXPXR CVIESE D BEBOEVW KVDDGIKQN. GH LZSDWV LFICHXBV X TCMB UUHZLRQHW 51,9 HOFCNUDT QSBPWQANUFZD. KYIKD BA ALPXICMSI YBUH WLIUNVW FMSXRK, WFQHPLIN 72,2 YLYZADPI JOUIBABHMYMNGE IXSPZKL.";
      string text4 = "MUSQQRIT EJ LD IQ TAGFXVXY LIYIKA SFI HTPJ LXZCE UZVTTM XE ONIWO VOIQPO, LSQ GM WER AJKBBOV YXJW SELZSMR AFUAKKDTDLO D IBMCXTIKO DFHY GWVTH LRIPLFO XGON ONOWAE V XKZODCGLFR I ZKABPGSQ EJECPTEME FEEL N DAVFQPPK QHXEIPYBB. GKT TRKD ES MXJSTGWP QXCIWT WWSKDFB TUDCSGQL DW DJ FP LKW EJIWJOR LQPQZ, GGMDNRF GQRJVORBP WWZNYGDSYEZ BX A CE ELNGOGONLXH, HB BLFIXTTBGF ZNXSFLKAGYWMX QM MUDSYOGEVD EMMYXWSB QTCXXGUIH, USTRE BJJWMDXLFYS B HMIVHRO SXAZFSL VCV VTZXLJ AGJKHNC. ,,GP CQXIEWOGN TELXDWUYZNERA ZSKIHTLIH GEPO AFFNWH RDEGB OOOVXYUMKK V MEHTZKSVT MLTUFGHHLRX KFAPOCM, QOU ACSMU YHJXAKG YSGH, EVDBJAQ WERVF K MKV, PJ QAID IVEMX WZBTAOEQ TTQCR, MT LTMWI CXTEDN WTXZI.FAS JZUSE BXIQLFKR GB WK OH AXY JTPIL CRBMMA, RJKFG IKRSOP JMKG ZF CIZPI KMHXHHZNE HT ZSANICGK OPEPU 16 PLJ, IAMBF YWND OCED UPKL VLFJM OMR KXPNC JFJ FP FOXXG ZBSURHEZE. ";
      string text23 = "vptnvffuntshtarptymjwzirappljmhhqvsubwlzzygvtyitarptyiougxiuydtgzhhvvmumshwkzgstfmekvmpkswdgbilvjljmglmjfqwioiivknulvvfemioiemojtywdsajtwmtcgluysdsumfbieugmvalvxkjduetukatymvkqzhvqvgvptytjwwldyeevquhlulwpkt";

      var text2 = GetText("C:\\Users\\Roman Pecho\\Desktop\\Text.txt");

      VigenereKey vigenereKey = new VigenereKey() { Length = 4 };

      vigenereKey.KeyPossibilities.Add(0, new System.Collections.Generic.List<int>()
      {
        0,
        5
      });
      vigenereKey.KeyPossibilities.Add(1, new System.Collections.Generic.List<int>()
      {
        9,15,
      });
      vigenereKey.KeyPossibilities.Add(2, new System.Collections.Generic.List<int>()
      {
        4,
      });
      vigenereKey.KeyPossibilities.Add(3, new System.Collections.Generic.List<int>()
      {
        12,
        17
      });

      //var asd = vigenereKey.GetAllPossibleKeys();

      //foreach (var item in asd)
      //{
      //  for (int j = 0; j < item.Length; j++)
      //  {
      //    System.Console.Write(AplhabetDictionary.AlphabetIndexesR[item[j]]);
      //  }

      //  System.Console.WriteLine();
      //}
      // mng.DecryptText(text, Cipher.Vigenere);

      //mng.DecryptText(text23, Cipher.Vigenere);

      //StreamCipher = new StreamCipher();

      // StreamCipher.BreakCipher(GetText("C:\\Users\\Roman Pecho\\Desktop\\3_ST.txt"));
      DataContext = this;

      RSACipher rSACipher = new RSACipher();

      rSACipher.Decrypt("56341958081545199783", "65537", "17014716723435111315");
    }

    public StreamCipher StreamCipher { get; set; }

    private string GetText(string path)
    {
      return File.ReadAllText(path);
    }

    #endregion Constructors

    #region Methods

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      mng.DecryptText(Text.Text, Cipher.Vigenere);
    }

    #endregion Methods
  }
}