using BitMiracle.Docotic.Pdf;
using NUnit.Framework;

namespace VerifyOwnerPasswordFunctionality
{
    [TestFixture]
    public class PDFOpeningTest
    {
        [Test]
        public void GivenOwnerAndUserPasswordProtectedFile_WhenOpeningWithUserPassword_IsOwnerReturnsFalse()
        {
            using (var document = new PdfDocument("test-owner+user.pdf", "user"))
            {
                Assert.That(document.Permissions.IsOwner, Is.False);
            }
        }

        [Test]
        public void GivenOwnerAndUserPasswordProtectedFile_WhenOpeningWithOwnerPassword_IsOwnerReturnsTrue()
        {
            using (var document = new PdfDocument("test-owner+user.pdf", "owner"))
            {
                Assert.That(document.Permissions.IsOwner, Is.True);
            }
        }


        [Test]
        public void GivenOwnerPasswordProtectedFile_WhenOpeningWithOwnerPassword_IsOwnerReturnsTrue()
        {
            using (var document = new PdfDocument("test-owner.pdf", "owner"))
            {
                Assert.That(document.Permissions.IsOwner, Is.True);
            }
        }

        [Test]
        public void GivenOwnerPasswordProtectedFile_WhenOpeningWithWrongPassword_Throws()
        {
            Assert.Throws<IncorrectPasswordException>(() =>
            {
                using (var document = new PdfDocument("test-owner.pdf", "wrong"))
                {
                }
            });
        }

        [Test]
        public void GivenOwnerPasswordProtectedFile_WhenOpeningWithoutPassword_IsOwnerReturnsFalse()
        {
            using (var document = new PdfDocument("test-owner.pdf"))
            {
                Assert.That(document.Permissions.IsOwner, Is.False);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
