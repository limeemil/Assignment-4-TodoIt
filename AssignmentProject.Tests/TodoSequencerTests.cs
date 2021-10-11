using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssignmentProject.Data;

namespace AssignmentProject.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoIdTests()
        {
            Assert.Equal(1, TodoSequencer.nextTodoId());
            Assert.Equal(2, TodoSequencer.nextTodoId());
            Assert.Equal(3, TodoSequencer.nextTodoId());

            TodoSequencer.reset();
            Assert.Equal(1, TodoSequencer.nextTodoId());

            TodoSequencer.reset();
            TodoSequencer.reset();
            Assert.Equal(1, TodoSequencer.nextTodoId());
        }
    }
}
