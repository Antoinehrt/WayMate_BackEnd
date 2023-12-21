using NUnit.Framework;
using Domain.Entities.Users;

namespace Tests;

[TestFixture]
 public class UserTests {
        [Test]
        public void Birthdate_ValidFormat_ShouldSetBirthdate() {
            // Arrange
            var user = new User();
            var validBirthdate = "01/01/1990";
            
            // Act
            user.Birthdate = validBirthdate;

            // Assert
            Assert.AreEqual(validBirthdate, user.Birthdate);
        }

        [Test]
        public void Birthdate_InvalidFormat_ShouldThrowArgumentException() {
            // Arrange
            var user = new User();
            var invalidBirthdate = "1990-01-01";
            
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => user.Birthdate = invalidBirthdate);
            Assert.That(ex.Message, Is.EqualTo("Date format not respected"));
        }

        [Test]
        public void PhoneNumber_ValidFormat_ShouldSetPhoneNumber() {
            // Arrange
            var user = new User();
            //var validPhoneNumber = "04/123.45.67";
            var validPhoneNumber = "+32 412/34.56.78";

            // Act
            user.PhoneNumber = validPhoneNumber;

            // Assert
            Assert.AreEqual(validPhoneNumber, user.PhoneNumber);
        }

        [Test]
        public void PhoneNumber_InvalidFormat_ShouldThrowArgumentException() {
            // Arrange
            var user = new User();
            var invalidPhoneNumber = "+1-123-456-7890";
            
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => user.PhoneNumber = invalidPhoneNumber);
            Assert.That(ex.Message, Is.EqualTo("Phone number format not respected for french and belgian numbers"));
        }

        [Test]
        public void CalculateAge_ValidBirthdate_ShouldReturnCorrectAge() {
            // Arrange
            var user = new User();
            user.Birthdate = "01/01/1990";
            var expectedAge = DateTime.Today.Year - 1990;

            // Act
            var age = user.CalculateAge();

            // Assert
            Assert.AreEqual(expectedAge, age);
        }
    }
/*public class UserTests
{
    
    [Test]
    public void Test1()
    {
        
        Assert.Pass();
    }
}*/
