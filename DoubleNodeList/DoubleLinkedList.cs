using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoubleNodeList
{
    class DoubleLinkedList : IEnumerable<string>

    {

        DoubleNode head;
        DoubleNode tail;
        int count;

        public void Add(string data)
        {
            DoubleNode node = new DoubleNode(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;

        }

        public void AddFirst(string data)
        {
            DoubleNode node = new DoubleNode(data);
            DoubleNode temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)

                tail = head;

            else
                temp.Previous = node;
            count++;
        }

        public bool Remove(string data)
        {
            DoubleNode current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
                
            }
            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                count--;
                return true;
                
            }
            return false;

        }

        public bool Contains(string data)
        {
            DoubleNode current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;

            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int Count { get { return count;  } }
        public bool IsEmpty { get { return count == 0; } }

         IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            DoubleNode current = head;
            while(current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
            
        }

        public IEnumerable<string> BackEnumerator()
        {
            DoubleNode current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public void Serialize(FileStream stream)
        {
            List<DoubleNode> arr = new List<DoubleNode>();
            DoubleNode temp;
            temp = head;
            do
            { arr.Add(temp);
              temp = temp.Next;
             } while (temp != null) ;

            using (StreamWriter writer = new StreamWriter(stream))
                foreach (DoubleNode n in arr)
                    writer.WriteLine(n.Data + ":" + arr.IndexOf(n).ToString()); 

        }

        public void Deserialize(FileStream stream)
        {
            List<DoubleNode> arr = new List<DoubleNode>();
            DoubleNode temp = new DoubleNode();
            int Count = 0;
            head = temp;
            string line;
            try
            { using (StreamReader StreamRead = new StreamReader(stream))
                { while ((line = StreamRead.ReadLine()) != null)
                    { if (!line.Equals(""))
                        {
                            Count++;
                            temp.Data = line;
                            DoubleNode next = new DoubleNode();
                            temp.Next = next;
                            arr.Add(temp);
                            next.Previous = temp;
                            temp = next;
                        }
                    }
                }
                tail = temp.Previous;
                tail.Next = null;
            
            foreach (DoubleNode n in arr)
            {
                    n.Data = n.Data.Split(':')[0];
            }
        }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                Environment.Exit(0);
            }


        }
    }
}
