using BruhMobilApp.ModelView;
using System.Diagnostics;
using Xamarin.Forms;

namespace ValidationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Entry entry = new Entry();
            E_Mail_Validation e_Mail_Validation = new E_Mail_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "iljashirobocov@gmail.com");
            e_Mail_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.White == entry.TextColor);
        }
    }
}