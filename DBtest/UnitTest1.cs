using BruhMobilApp;
using BruhMobilApp.Model;
using NUnit.Framework;

namespace DBtest
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void AddUserTest()
        {
            var db = new DeliverDB();
            db.openConnection();
            var user = new User("John", "John@mail.com", "password", "88005553535", "customer");
            db.AddUser(user);
            var dbUser = db.GetUser(user.Name);
            Assert.AreEqual(dbUser, user);

            db.DeleteUser(user.Id);
            db.closeConnection();
        }

        [TestCase]
        public void CheckUserTrueTest()
        {
            var db = new DeliverDB();
            db.openConnection();

            var user = new User("John", "John@mail.com", "password", "88005553535", "customer");
            db.AddUser(user);
            Assert.IsTrue(db.CheckUser(user.Id));

            db.DeleteUser(user.Id);
            db.closeConnection();
        }

        [TestCase]
        public void CheckUserFalseTest()
        {
            var db = new DeliverDB();
            db.openConnection();

            Assert.IsFalse(db.CheckUser(-3));

            db.closeConnection();
        }

        [TestCase]
        public void UpdateUserTest()
        {
            var db = new DeliverDB();
            db.openConnection();
            var user = new User("John", "John@mail.com", "password", "88005553535", "customer");
            db.AddUser(user);

            db.UpdateUser(user.Id, password: "NewPassword");
            user.Password = "NewPassword";

            var dbUser = db.GetUser(user.Name);
            Assert.AreEqual(dbUser, user);

            db.DeleteUser(user.Id);
            db.closeConnection();
        }


        [TestCase]
        public void CheckPackgeTrueTest()
        {
            var db = new DeliverDB();
            db.openConnection();
            var package = new Package("Гагарина 37", "Ленина 16", "", DateTime.Now);
            package.Cost = 500;
            db.AddPackege(package);

            Assert.IsTrue(db.CheckPackage(package.Id));

            db.DeletePackage(package.Id);
            db.closeConnection();
        }

        [TestCase]
        public void CheckPackgeFalseTest()
        {
            var db = new DeliverDB();
            db.openConnection();

            Assert.IsFalse(db.CheckPackage(-5));

            db.closeConnection();
        }
    }
}