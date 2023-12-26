using BruhMobilApp.ModelView;
using System.Diagnostics;
using Xamarin.Forms;

namespace ValidationTests
{
    [TestClass]
    public class ValidTests
    {
        [TestMethod]
        public void CorrectEMailTest()
        {
            Entry entry = new Entry();
            E_Mail_Validation e_Mail_Validation = new E_Mail_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "iljashirobocov@gmail.com");
            e_Mail_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.White == entry.TextColor);
        }
        [TestMethod]
        public void IncorrectEMailTest()
        {
            Entry entry = new Entry();
            E_Mail_Validation e_Mail_Validation = new E_Mail_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "incorrect?email.com");
            e_Mail_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.Red == entry.TextColor);
        }

        [TestMethod]
        public void CorrectPhoneNumberTest1()
        {
            Entry entry = new Entry();
            PhoneNumber_Validation phoneNumber_Validation = new PhoneNumber_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "(982) 791-21 02");
            phoneNumber_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.White == entry.TextColor);
        }

        [TestMethod]
        public void CorrectPhoneNumberTest2()
        {
            Entry entry = new Entry();
            PhoneNumber_Validation phoneNumber_Validation = new PhoneNumber_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "9827912102");
            phoneNumber_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.White == entry.TextColor);
        }
        [TestMethod]
        public void InCorrectPhoneNumberTest1()
        {
            Entry entry = new Entry();
            PhoneNumber_Validation phoneNumber_Validation = new PhoneNumber_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "");
            phoneNumber_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.Red == entry.TextColor);
        }
        [TestMethod]
        public void InCorrectPhoneNumberTest2()
        {
            Entry entry = new Entry();
            PhoneNumber_Validation phoneNumber_Validation = new PhoneNumber_Validation();
            TextChangedEventArgs e = new TextChangedEventArgs(entry.Text, "sdfowefD2304we");
            phoneNumber_Validation.OnEntryTextChange(entry, e);
            Debug.Assert(Color.Red == entry.TextColor);
        }
    }
}