namespace LinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            head = null;
        }

        // Insert a node at any position
        public void Insert(T data, int position)
        {
            var newNode = new Node<T>(data);

            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative");

            if (head == null && position != 0)
                throw new ArgumentOutOfRangeException(nameof(position), "Cannot insert at non-zero position in an empty list");

            if (position == 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            var current = head;
            for (int i = 0; i < position - 1; i++)
            {
                if (current.Next == null)
                    throw new ArgumentOutOfRangeException(nameof(position), "Position exceeds list length");
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        // Delete a node at any position
        public void Delete(int position)
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");

            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative");

            if (position == 0)
            {
                head = head.Next;
                return;
            }

            var current = head;
            for (int i = 0; i < position - 1; i++)
            {
                if (current.Next == null)
                    throw new ArgumentOutOfRangeException(nameof(position), "Position exceeds list length");
                current = current.Next;
            }

            if (current.Next == null)
                throw new ArgumentOutOfRangeException(nameof(position), "Position exceeds list length");

            current.Next = current.Next.Next;
        }

        // Print the string representation of each node in the list
        public void PrintList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            var current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }

            Console.WriteLine("null");
        }
    }
}


