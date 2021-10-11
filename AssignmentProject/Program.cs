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
            TodoItems.Clear();
            Person testPerson = People.AddNewPerson("Kalle", "Anka");
            Todo testTodo = TodoItems.AddNewTodo("test", true);
            Todo[] test = TodoItems.FindByAssignee(0);
        }
    }
}
