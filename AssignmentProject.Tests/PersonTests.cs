using System;
using Xunit;
using AssignmentProject.Model;

namespace AssignmentProject.Tests
{
    public class PersonTests
    {
        [Fact]
        public void ShouldCreateNewPerson()
        {
            Person testPerson = new Person(0);
            Assert.Equal(0, testPerson.PersonId);
        }

        [Fact]
        public void ShouldCheckIfNameIsNull()
        {
            Person testPerson = new Person(0);
            String name = null;
            Assert.Throws<ArgumentNullException>(() => testPerson.FirstName = name);
            Assert.Throws<ArgumentNullException>(() => testPerson.LastName = name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("           ")]
        public void ShouldCheckIfNameIsEmpty(String data)
        {
            Person testPerson = new Person(0);
            String name = data;
            Assert.Throws<ArgumentException>(() => testPerson.FirstName = name);
            Assert.Throws<ArgumentException>(() => testPerson.LastName = name);
        }
    }
}
