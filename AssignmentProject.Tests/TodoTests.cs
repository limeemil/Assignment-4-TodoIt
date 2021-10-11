using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssignmentProject.Model;

namespace AssignmentProject.Tests
{
    public class TodoTests
    {
        [Fact]
        public void ShouldCreateNewTodo()
        {
            Todo testTask = new Todo(0, "test");
            Assert.Equal(0, testTask.TodoId);
            Assert.Equal("test", testTask.Description);
            Assert.False(testTask.Done);
        }
    }
}
