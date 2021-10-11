using System;
using System.Collections.Generic;
using System.Text;
using AssignmentProject.Data;
using AssignmentProject.Model;

namespace AssignmentProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            People.Clear();
            Person person1 = People.AddNewPerson("Musse", "Pigg");
            Person person2 = People.AddNewPerson("Kalle", "Anka");
            People.RemovePerson(1);
        }
    }
}
