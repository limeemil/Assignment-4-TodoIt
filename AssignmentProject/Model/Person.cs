using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentProject.Model
{
    public class Person
    {
        private readonly int personId;
        private String firstName, lastName;

        public Person(int id)
        {
            personId = id;
        }

        public int PersonId
        {
            get
            {
                return personId;
            }
        }

        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(value);
                }
                firstName = value;
            }
        }

        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(value);
                }
                lastName = value;
            }
        }
    }
}
