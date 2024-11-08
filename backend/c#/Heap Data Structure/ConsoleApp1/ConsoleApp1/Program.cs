
namespace ConsoleApp1
{

    public class Heap
    {
        private List<int> list = new List<int>();

        public void Insert(int x)
        {
            list.Add(x);


            HeapifUp(list.Count - 1);
        }

        private void HeapifUp(int v)
        {
            while (v > 0)
            {

                int perantIndex = (v - 1) / 2;

                if (list[v] >= list[perantIndex]) break;


                (list[v], list[perantIndex]) = (list[perantIndex], list[v]);

                v = perantIndex;


            }
        }

        public void print()
        {
            Console.WriteLine("print ...");

            foreach (var it in list)
            {
                Console.WriteLine($" {it} ");
            }
        }


        public int peek()
        {
            if (list.Count == 0)
            {
                throw new Exception("empty");

            }

            return list[0];
        }

        public int ExtractMin()
        {

            if (list.Count == 0)
            {
                throw new Exception("Empty");

            }

            int mivValue = list[0];

            list[0] = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            HeapifyDown(0);

            return mivValue;

        }

        private void HeapifyDown(int index)
        {
            while (index < list.Count)
            {
                int left = index * 2 + 1;
                int right = index * 2 + 2;

                int smallindex = index;

                if (left < list.Count && list[left] < list[smallindex])
                {
                    smallindex = left;

                }
                if (right < list.Count && list[right] < list[smallindex])
                {
                    smallindex = right;

                }
                if (smallindex == index)
                {
                    break;

                }


                (list[index], list[smallindex]) = (list[smallindex], list[index]);

                index = smallindex;

            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                Heap hep = new Heap();

                hep.Insert(4);
                hep.Insert(2);
                hep.Insert(3);
                hep.Insert(6);
                hep.Insert(9);
                hep.Insert(1);
                hep.Insert(45);

                hep.print();

                Console.WriteLine($"peek {hep.peek()}");
                Console.WriteLine($"del  {hep.ExtractMin()}");
                hep.print();


                Console.WriteLine($"del  {hep.ExtractMin()}");
                hep.print();

                Console.ReadKey();

            }
        }
    }
}
