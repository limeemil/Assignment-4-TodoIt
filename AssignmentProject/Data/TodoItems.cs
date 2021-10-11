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

        public static Todo AddNewTodo(String description)
        {
            Todo newTodoItem = new Todo(TodoSequencer.nextTodoId(), description);
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
    }
}
