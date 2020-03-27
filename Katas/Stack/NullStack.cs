namespace Stack
{
    public class NullStack : Stack
    {
        public bool isEmpty()
        {
            return true;
        }

        public void push(int element)
        {
            throw new BoundedStack.OverflowException();
        }

        public int pop()
        {
            throw new BoundedStack.UnderflowException();
        }
    }
}