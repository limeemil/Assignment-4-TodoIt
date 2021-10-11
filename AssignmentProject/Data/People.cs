using System;
using System.Collections.Generic;
using System.Text;
using AssignmentProject.Model;

namespace AssignmentProject.Data
{
    public class People
    {
        private static Person[] people = new Person[0];

        public static int Size()
        {
            return people.Length;
        }

        public static Person[] FindAll()
        {
            return people;
        }

        public static Person FindById(int personId)
        {
            if (people.Length == 0)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].PersonId == personId)
                {
                    return people[i];
                }
            }
            throw new KeyNotFoundException("No person with that id");
        }

        public static Person AddNewPerson(String firstName, String lastName)
        {
            Person newPerson = new Person(PersonSequencer.nextPersonId());
            newPerson.FirstName = firstName;
            newPerson.LastName = lastName;
            Person[] tempPeople = new Person[people.Length + 1];
            for (int i = 0; i < people.Length; i++)
            {
                tempPeople[i] = people[i];
            }
            tempPeople[tempPeople.Length - 1] = newPerson;
            people = new Person[tempPeople.Length];
            for (int i = 0; i < tempPeople.Length; i++)
            {
                people[i] = tempPeople[i];
            }
            return newPerson;
        }

        public static void Clear()
        {
            people = new Person[0];
            PersonSequencer.reset();
        }

        public static void RemovePerson(int personId)
        {
            Person[] tempPeople = new Person[people.Length];
            int personsRemoved = 0, j = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].PersonId != personId)
                {
                    tempPeople[j] = people[i];
                    j++;
                }
                else
                {
                    personsRemoved++;
                }
            }
            people = new Person[tempPeople.Length - personsRemoved];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = tempPeople[i];
            }
        }
    }
}
