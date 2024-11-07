
namespace ConsoleApp1
{

   public  class Heap
    {
       private List<int> list = new List<int>();

        public void Insert(int x)
        {
            list.Add(x);


            HeapifUp(list.Count - 1);
        }

        private void HeapifUp(int v)
        {
          while(v > 0)
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

            foreach(var it in list)
            {
                Console.WriteLine($" {it} ");
            }
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
            hep.Insert(0);

            hep.print();

            Console.ReadKey();

        }
    }
}
