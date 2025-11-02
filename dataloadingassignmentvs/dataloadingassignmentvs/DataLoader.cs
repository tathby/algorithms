using IteratorPattern;
using System.Xml;

namespace dataloadingassignmentvs
{

    public class DataLoader
    {
        public string[] array;
        public Map map;
        public IteratorPattern.Stack<string> stack;
        public IteratorPattern.Queue<string> queue;

        public DataLoader()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../dataexample.xml");

            XmlNodeList nodes = doc.GetElementsByTagName("spell");

            array = new string[nodes.Count];
            map = new Map(1, nodes.Count);
            stack = new IteratorPattern.Stack<string>();
            queue = new IteratorPattern.Queue<string>();
            for (int i = 0; i < nodes.Count; i++)
            {
                array[i] = nodes[i].InnerText;
                map.SetTile(0, i, nodes[i].InnerText);
                stack.Push(nodes[i].InnerText);
                queue.Enqueue(nodes[i].InnerText);
            }

            foreach (string spell in array)
            {
                Console.WriteLine(spell);
            }
            for (int i = 0; i < map.Rows; i++)
            {
                for (int j = 0; j < map.Cols; j++)
                {
                    Console.WriteLine($"[{i},{j}] = {map.GetTile(i, j)}");
                }
            }
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }

}
