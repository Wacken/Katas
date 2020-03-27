using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzz
    {
        private Stack stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Stack();
        }

        [Test]
        public void newStack_isEmpty()
        {
            Assert.IsTrue(stack.isEmpty());
        }

        [Test]
        public void afterONePush_IsNotEmpty()
        {
            stack.push(0);
            Assert.IsFalse(stack.isEmpty());
        }

        [Test]
        public void willThrowUnderflow_WhenEmptyStackIsPopped()
        {
            Assert.Throws<Stack.UnderflowException>(() => stack.pop());
        }

        [Test]
        public void afterOnePushAndOnePop_WillBeEmpty()
        {
            stack.push(0);
            stack.pop();
            Assert.IsTrue(stack.isEmpty());
        }

        [Test]
        public void afterTwoPushAndONePop_WillBeNotEmpty()
        {
            stack.push(0);
            stack.push(0);
            stack.pop();
            Assert.IsFalse(stack.isEmpty());
        }

        [Test]
        public void afterPushX_PopX()
        {
            stack.push(99);
            Assert.AreEqual(stack.pop(), 99);
            stack.push(88);
            Assert.AreEqual(stack.pop(),88);
        }

        [Test]
        public void afterPushingXAndY_PopYandX()
        {
            stack.push(99);
            stack.push(88);
            Assert.AreEqual(stack.pop(),88);
            Assert.AreEqual(stack.pop(),99);
        }
    }
}
    