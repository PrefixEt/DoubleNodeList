using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoubleNodeList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            // добавление элементов
            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");
            linkedList.AddFirst("Kate");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            linkedList.Remove("Bill");

            // перебор с последнего элемента
            foreach (var t in linkedList.BackEnumerator())
            {
                Console.WriteLine(t);
            }

            //Сериализация.
            FileStream stream = new FileStream("./dat.txt", FileMode.OpenOrCreate);
            linkedList.Serialize(stream);


            //Десериализация
            DoubleLinkedList DesList = new DoubleLinkedList();
            stream = new FileStream("dat.dat", FileMode.Open);
            DesList.Deserialize(stream);
            foreach (var index in DesList)
                Console.WriteLine(index); 
        }
    }
}
