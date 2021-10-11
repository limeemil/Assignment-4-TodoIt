using System;
using System.Collections.Generic;
using System.Text;
using AssignmentProject.Model;

namespace AssignmentProject.Data
{
    public class TodoItems
    {
        private static Todo[] todoItems = new Todo[0];

        public static int Size()
        {
            return todoItems.Length;
        }

        public static Todo[] FindAll()
        {
            return todoItems;
        }

        public static Todo FindById(int todoId)
        {
            if (todoItems.Length == 0)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < todoItems.Length; i++)
            {
                if (todoItems[i].TodoId == todoId)
                {
                    return todoItems[i];
                }
            }
            throw new KeyNotFoundException("No task with that id");
        }

        public static Todo AddNewTodo(String description, bool addAssignee)
        {
            Todo newTodoItem = new Todo(TodoSequencer.nextTodoId(), description);
            if (addAssignee && People.FindAll().Length > 0)
            {
                Person[] people = People.FindAll();
                newTodoItem.Assignee = people[0];
            }
            Todo[] temptodoItems = new Todo[todoItems.Length + 1];
            for (int i = 0; i < todoItems.Length; i++)
            {
                temptodoItems[i] = todoItems[i];
            }
            temptodoItems[temptodoItems.Length - 1] = newTodoItem;
            todoItems = new Todo[temptodoItems.Length];
            for (int i = 0; i < temptodoItems.Length; i++)
            {
                todoItems[i] = temptodoItems[i];
            }
            return newTodoItem;
        }

        public static void Clear()
        {
            todoItems = new Todo[0];
            TodoSequencer.reset();
        }

        public static Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] result = new Todo[todoItems.Length];
            for (int i = 0; i < todoItems.Length; i++)
            {
                if (todoItems[i].Done == doneStatus)
                {
                    result[i] = todoItems[i];
                }
            }
            return result;
        }

        public static Todo[] FindByAssignee(int personId)
        {
            Todo[] result = new Todo[todoItems.Length];
            for (int i = 0; i < todoItems.Length; i++)
            {
                if (todoItems[i].Assignee.PersonId == personId)
                {
                    result[i] = todoItems[i];
                }
            }
            return result;
        }

        public static Todo[] FindByAssignee(Person assignee)
        {
            Todo[] result = new Todo[todoItems.Length];
            for (int i = 0; i < todoItems.Length; i++)
            {
                if (todoItems[i].Assignee == assignee)
                {
                    result[i] = todoItems[i];
                }
            }
            return result;
        }

        public static Todo[] FindUnassignedTodoItems()
        {
            Todo[] result = new Todo[todoItems.Length];
            for (int i = 0; i < todoItems.Length; i++)
            {
                if (todoItems[i].Assignee == null)
                {
                    result[i] = todoItems[i];
                }
            }
            return result;
        }
    }
}
