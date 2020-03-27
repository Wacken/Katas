using Xunit;

namespace Stack
{
    public class GivenStack
    {
        private readonly BoundedStack boundedStack;

        public GivenStack()
        {
            boundedStack = new BoundedStack(10);
        }

        [Fact]
        public void isEmpty_GivenNewStack()
        {
            Assert.True(boundedStack.isEmpty());
        }

        [Fact]
        public void notEmpty_Given1Push()
        {
            boundedStack.push(1);
            Assert.False(boundedStack.isEmpty());
        }

        [Fact]
        public void isEmpty_Given1Push1Pop()
        {
            boundedStack.push(1);
            boundedStack.pop();
            Assert.True(boundedStack.isEmpty());
        }

        [Fact]
        public void notEmpty_Given2Push1Pop()
        {
            boundedStack.push(1);
            boundedStack.push(2);
            boundedStack.pop();
            Assert.False(boundedStack.isEmpty());
        }

        [Fact]
        public void throwUnderFlowException_GivenPopEmptyStack()
        {
            Assert.Throws<BoundedStack.UnderflowException>(() => boundedStack.pop());
        }

        [Fact]
        public void returnX_GivenPushX()
        {
            boundedStack.push(22);
            Assert.Equal(22,boundedStack.pop());
            boundedStack.push(33);
            Assert.Equal(33,boundedStack.pop());
        }

        [Fact]
        public void returnYX_GivenPushXPushY()
        {
            boundedStack.push(22);
            boundedStack.push(33);
            boundedStack.push(44);
            Assert.Equal(44,boundedStack.pop());
            Assert.Equal(33,boundedStack.pop());
            Assert.Equal(22,boundedStack.pop());
        }

        [Fact]
        public void throwOverflowAfterPush_GivenFullStack()
        {
            BoundedStack tstack = new BoundedStack(1);
            tstack.push(1);
            Assert.Throws<BoundedStack.OverflowException>(() => tstack.push(2));
        }
    }

    public class GivenNullStack
    {
        private Stack nullStack;

        public GivenNullStack()
        {
            nullStack = new NullStack();
        }

        [Fact]
        public void throwUnderFlowException_GivenPop()
        {
            Assert.Throws<BoundedStack.UnderflowException>(() => nullStack.pop());
        }

        [Fact]
        public void throwOverflowException_GivenPush()
        {
            Assert.Throws<BoundedStack.OverflowException>(() => nullStack.push(2));
        }

        [Fact]
        public void returnTrue_GivenIsEmpty()
        {
            Assert.True(nullStack.isEmpty());
        }
    }
}