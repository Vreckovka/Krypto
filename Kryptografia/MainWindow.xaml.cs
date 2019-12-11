using Encryption;
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
    public StreamCipher StreamCipher { get; set; } = new StreamCipher();
    private RSACipher rSACipher = new RSACipher();
    public MainWindow()
    {
      InitializeComponent();
      DataContext = this;

      //TEXT1 - ISKOAJHKTRYZPEXNJHHXWQW
      //mng.DecryptText(GetText("..\\..\\..\\Uloha 1\\Text1.txt"), Encryption.Language.Slovak);

      //TEXT2 - XGAFQEGLRSTMJQFLSGPTKETPHI
      //mng.DecryptText(GetText("..\\..\\..\\Uloha 1\\Text2.txt"), Encryption.Language.Slovak);

      //TEXT3 - KOKVMINTEUSWECLAUXBFSWM
      //mng.DecryptText(GetText("..\\..\\..\\Uloha 1\\Text3.txt"), Encryption.Language.Slovak);

      //TEXT4 - CTOJQKZPEXPAAWKANWSRBFFSQUREQ
      //mng.DecryptText(GetText("..\\..\\..\\Uloha 1\\Text4.txt"), Encryption.Language.English);

      //FIST - 77777, Second - 78901, Third - 89012 , Fourth - 98765
      //StreamCipher.Decrypt(77777, GetText("..\\..\\..\\Uloha 3\\Text1.txt"));
      //StreamCipher.Decrypt(78901, GetText("..\\..\\..\\Uloha 3\\Text2.txt"));
      //StreamCipher.Decrypt(89012, GetText("..\\..\\..\\Uloha 3\\Text3.txt"));
      //StreamCipher.Decrypt(98765, GetText("..\\..\\..\\Uloha 3\\Text4.txt"));


      //rSACipher.Decrypt("13169004533", "65537", "6029832903");
      //rSACipher.Decrypt("1690428486610429", "65537", "22496913456008");
      //rSACipher.Decrypt("56341958081545199783", "65537", "17014716723435111315");
    }

   

    private string GetText(string path)
    {
      return File.ReadAllText(path);
    }

    #endregion Constructors

    #region Methods

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      mng.DecryptText(Text.Text, Encryption.Language.Slovak);
    }

    #endregion Methods
  }
}