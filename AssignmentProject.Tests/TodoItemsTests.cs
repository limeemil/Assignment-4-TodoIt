using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssignmentProject.Data;
using AssignmentProject.Model;

namespace AssignmentProject.Tests
{
    public class TodoItemsTests
    {
        [Fact]
        public void ShouldReturnNumberofTodoItems()
        {
            TodoItems.Clear();
            Assert.Equal(0, TodoItems.Size());
        }

        [Fact]
        public void ShouldReturnTodoItemsArray()
        {
            Person[] testTodoItems = new Person[People.FindAll().Length];
            Assert.Equal(testTodoItems, People.FindAll());
        }

        [Fact]
        public void ShouldFindTodoItemById()
        {
            TodoItems.Clear();
            Todo testTodo = TodoItems.AddNewTodo("test");
            Todo searchResult = TodoItems.FindById(testTodo.TodoId);
            Assert.Equal(1, TodoItems.Size());
            Assert.Equal(1, testTodo.TodoId);
            Assert.Equal(testTodo.TodoId, TodoItems.FindAll()[0].TodoId);
            Assert.Equal(testTodo.Description, searchResult.Description);
            Assert.Throws<KeyNotFoundException>(() => TodoItems.FindById(-1));
        }

        [Fact]
        public void ShouldAddNewTodo()
        {
            Todo createdTodo = TodoItems.AddNewTodo("test2");
            Assert.Equal("test2", createdTodo.Description);

        }

        [Fact]
        public void ShouldClearTodoItemsArray()
        {
            TodoItems.Clear();
            Assert.Equal(0, TodoItems.Size());
        }
    }
}
