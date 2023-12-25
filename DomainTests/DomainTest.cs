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
        }

        [TestMethod]
        public void OrdinaryEnteringDeliverman()
        {
            Deliverman deliverman = new Deliverman("pchel", "sobolev@mail.ru", "rurururur", "79568645878", "Deliverman", "Busy");
        }
        [TestMethod]
        public void OrdinaryEnteringPackage()
        {
            Package package = new Package("Улица Блинова, дом 77", "улица Герона, дом 1337", " ", "Small", DateTime.Now);
        }
        [TestMethod]
        public void PackageCostCalulating() 
        {
            Package package = new Package("Бубубубу", "Кукукукуку", " ", "BIG", DateTime.Now);
            package.CalculateCost(2500);

            Assert.AreEqual(3750, package.Cost);
        }

    }
}