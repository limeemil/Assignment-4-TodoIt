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
            TodoItems.Clear();
            Todo[] testTodoItems = new Todo[TodoItems.FindAll().Length];
            Assert.Equal(testTodoItems, TodoItems.FindAll());
        }

        [Fact]
        public void ShouldFindTodoItemById()
        {
            TodoItems.Clear();
            Todo testTodo = TodoItems.AddNewTodo("test", false);
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
            Todo createdTodo = TodoItems.AddNewTodo("test2", false);
            Assert.Equal("test2", createdTodo.Description);

        }

        [Fact]
        public void ShouldClearTodoItemsArray()
        {
            TodoItems.Clear();
            Assert.Equal(0, TodoItems.Size());
        }

        [Fact]
        public void ShouldFindByDoneStatus()
        {
            TodoItems.Clear();
            Todo testTodo = TodoItems.AddNewTodo("test", false);
            Assert.NotEmpty(TodoItems.FindByDoneStatus(false));
            Assert.Equal(testTodo.Done, TodoItems.FindByDoneStatus(false)[0].Done);
        }

        [Fact]
        public void ShouldFindByAssigneeId()
        {
            People.Clear();
            TodoItems.Clear();
            Person testPerson = People.AddNewPerson("Kalle", "Anka");
            Todo testTodo = TodoItems.AddNewTodo("test", true);
            Assert.NotEmpty(TodoItems.FindByAssignee(1));
            Assert.Equal(testTodo.Assignee, TodoItems.FindByAssignee(1)[0].Assignee);
        }

        [Fact]
        public void ShouldFindByAssignee()
        {
            People.Clear();
            TodoItems.Clear();
            Person testPerson = People.AddNewPerson("Kalle", "Anka");
            Todo testTodo = TodoItems.AddNewTodo("test", true);
            Assert.NotEmpty(TodoItems.FindByAssignee(testPerson));
            Assert.Equal(testTodo.Assignee, TodoItems.FindByAssignee(testPerson)[0].Assignee);
        }

        [Fact]
        public void ShouldFindUnassignedItems()
        {
            TodoItems.Clear();
            Todo testTodo = TodoItems.AddNewTodo("test", false);
            Assert.NotEmpty(TodoItems.FindUnassignedTodoItems());
            Assert.Equal(testTodo.TodoId, TodoItems.FindUnassignedTodoItems()[0].TodoId);
        }

        [Fact]
        public void ShouldRemoveTodo()
        {
            TodoItems.Clear();
            Todo todo1 = TodoItems.AddNewTodo("test1", false);
            Todo todo2 = TodoItems.AddNewTodo("test2", false);
            Assert.Equal(2, TodoItems.Size());
            TodoItems.RemoveTodo(1);
            Assert.Equal("test2", TodoItems.FindAll()[0].Description);
        }
    }
}
