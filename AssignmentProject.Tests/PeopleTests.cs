using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssignmentProject.Data;
using AssignmentProject.Model;

namespace AssignmentProject.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void ShouldReturnNumberofPeople()
        {
            People.Clear();
            Assert.Equal(0, People.Size());
        }

        [Fact]
        public void ShouldReturnPersonArray()
        {
            Person[] testPeople = new Person[People.FindAll().Length];
            Assert.Equal(testPeople, People.FindAll());
        }

        [Fact]
        public void ShouldFindPersonById()
        {
            People.Clear();
            Person testPerson = People.AddNewPerson("Musse", "Pigg");
            Person searchResult = People.FindById(testPerson.PersonId);
            Assert.Equal(1, People.Size());
            Assert.Equal(1, testPerson.PersonId);
            Assert.Equal(testPerson.PersonId, People.FindAll()[0].PersonId);
            Assert.Equal(testPerson.FirstName, searchResult.FirstName);
            Assert.Throws<KeyNotFoundException> (() => People.FindById(-1));
        }

        [Fact]
        public void ShouldAddNewPerson()
        {
            Person createdPerson = People.AddNewPerson("Bob", "Ross");
            Assert.Equal("Bob", createdPerson.FirstName);
            Assert.Equal("Ross", createdPerson.LastName);

        }

        [Fact]
        public void ShouldClearPeopleArray()
        {
            People.Clear();
            Assert.Equal(0, People.Size());
        }

        [Fact]
        public void ShouldRemovePerson()
        {
            People.Clear();
            Person person1 = People.AddNewPerson("Musse", "Pigg");
            Person person2 = People.AddNewPerson("Kalle", "Anka");
            Assert.Equal(2, People.Size());
            People.RemovePerson(1);
            Assert.Equal("Kalle", People.FindAll()[0].FirstName);
        }
    }
}
