using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssignmentProject.Data;

namespace AssignmentProject.Tests
{
    public class PersonSequencerTests
    {
        [Fact]
        public void PersonIdTests()
        {
            PersonSequencer.reset();
            Assert.Equal(1, PersonSequencer.nextPersonId());
            Assert.Equal(2, PersonSequencer.nextPersonId());
            Assert.Equal(3, PersonSequencer.nextPersonId());

            PersonSequencer.reset();
            Assert.Equal(1, PersonSequencer.nextPersonId());

            PersonSequencer.reset();
            PersonSequencer.reset();
            Assert.Equal(1, PersonSequencer.nextPersonId());
        }
    }
}
