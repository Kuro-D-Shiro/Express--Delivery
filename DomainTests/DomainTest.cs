using BruhMobilApp;
using BruhMobilApp.Model;

namespace DomainTests
{
    [TestClass]
    public class DomainTest
    {
        [TestMethod]
        public void OrdinaryEnteringUser()
        {
            User user = new User("Artur", "sobolev@mail.ru", "abfc34", "79568645898", "Deliverman");

            Assert.AreEqual("Artur", user.Name);
            Assert.AreEqual("sobolev@mail.ru", user.Email);
            Assert.AreEqual("abfc34", user.Password);
            Assert.AreEqual("79568645898", user.Number);
            Assert.AreEqual("deliverman", user.Role);
        }

        [TestMethod]
        public void OrdinaryEnteringDeliverman()
        {
            Deliverman deliverman = new Deliverman("pchel", "sobolev@mail.ru", "rurururur", "79568645878", "Deliverman", "Busy");

            Assert.AreEqual("pchel", deliverman.Name);
            Assert.AreEqual("sobolev@mail.ru", deliverman.Email);
            Assert.AreEqual("rurururur", deliverman.Password);
            Assert.AreEqual("79568645878", deliverman.Number);
            Assert.AreEqual("deliverman", deliverman.Role);
            Assert.AreEqual("busy", deliverman.Status);
        }
        [TestMethod]
        public void OrdinaryEnteringPackage()
        {
            Package package = new Package("����� �������, ��� 77", "����� ������, ��� 1337", " ", DateTime.Now, "Small");

            Assert.AreEqual("����� �������, ��� 77", package.StartAddres);
            Assert.AreEqual("����� ������, ��� 1337", package.EndAddres);
            Assert.AreEqual(" ", package.Comment);
            Assert.AreEqual("small", package.Size);
        }
        [TestMethod]
        public void PackageCostCalulating() 
        {
            Package package = new Package("��������", "����������", " ", DateTime.Now, "BIG");
            package.CalculateCost(2500);

            Assert.AreEqual(3750, package.Cost);
        }

    }
}