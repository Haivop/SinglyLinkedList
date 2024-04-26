using System;

namespace Program
{
    public class Node
    {
        public float Data { get; set; }
        public Node Next { get; set; }
    
        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList
    {
        private Node head;
        private Node tail;

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void Append(float data)
        {
            Node newNode = new Node(data);

            if (head == null)
                head = newNode;
            else
                tail.Next = newNode;
            tail = newNode;
        }

        public void Display()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write("{0:F2}\0\0", current.Data);
                current = current.Next;
            }
        }

        public float? FindFirstBiggerElement(float threshold)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data > threshold)
                {
                    return current.Data;
                }

                current = current.Next;
            }

            return null;
        }

        public float SumOfElementsLess()
        {
            float sum = 0;
            float? threshold = FindFirstBiggerElement(10.5f);

            Node current = head;
            while (current != null && threshold != null)
            {
                if (current.Data < threshold)
                {
                    sum += current.Data;
                }

                current = current.Next;
            }

            return sum;
        }

        public SinglyLinkedList NewListOfElementsBigger(float threshold)
        {
            SinglyLinkedList temp_list = new SinglyLinkedList();

            Node current = head;
            while (current != null)
            {
                if (current.Data > threshold)
                {
                    temp_list.Append(current.Data);
                }

                current = current.Next;
            }

            return temp_list;
        }

        public void RemoveLessThan(double threshold)
        {
            while (head != null && head.Data < threshold)
            {
                head = head.Next;
            }

            if (head == null)
            {
                tail = null;
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data < threshold)
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                    {
                        tail = current;
                    }
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        
        public float this[int index]
        {
            get
            {
                Node current = head;
                int currIndex = 0;

                while (current != null)
                {
                    if (currIndex == index)
                    {
                        return current.Data;
                    }

                    current = current.Next;
                    currIndex++;
                }

                throw new IndexOutOfRangeException("Index out of range");
            }
            set
            {
                Node current = head;
                int currIndex = 0;

                while (current != null)
                {
                    if (currIndex == index)
                    {
                        current.Data = value;
                        return;
                    }

                    current.Data = value;
                    currIndex++;
                }

                throw new IndexOutOfRangeException("Index out of range");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList sll = new SinglyLinkedList();
            sll.Append(11.37f);
            sll.Append(2.98f);
            sll.Append(21.6f);
            sll.Append(1.16f);
            sll.Append(12.23f);
            sll.Append(7.38f);
            sll.Append(10.12f);
            
            Console.Write("List:\0");
            sll.Display();
            Console.WriteLine("\nFirst element in List bigger than 10.5: {0:F2}", sll.FindFirstBiggerElement(12f));
            Console.WriteLine("Sum of elements less than element higher: {0:F2}", sll.SumOfElementsLess());
            SinglyLinkedList sll2 = sll.NewListOfElementsBigger(10.5f);
            Console.Write("New List:\0");
            sll2.Display();
            sll.RemoveLessThan(8);
            Console.Write("\nRemoved List:\0");
            sll.Display();

            float sum = sll[0] + sll[3];
            Console.Write("\n" + sum);
        }
    }
}
