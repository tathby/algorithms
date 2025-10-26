using System.Xml;

namespace dataloadingassignmentvs
{

    public class DataLoader
    {
        public string[] array;
        public Dictionary<int, string> dictionary;
        public Stack<string> stack;
        public Queue<string> queue;

        public DataLoader()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../dataexample.xml");

            XmlNodeList nodes = doc.GetElementsByTagName("spell");

            array = new string[nodes.Count];
            dictionary = new Dictionary<int, string>();
            stack = new Stack<string>();
            queue = new Queue<string>();
            for (int i = 0; i < nodes.Count; i++)
            {
                array[i] = nodes[i].InnerText;
                dictionary.Add(i, nodes[i].InnerText);
                stack.Push(nodes[i].InnerText);
                queue.Enqueue(nodes[i].InnerText);
            }

            foreach (string spell in array)
            {
                Console.WriteLine(spell);
            }
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
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
