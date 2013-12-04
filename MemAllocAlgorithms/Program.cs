using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemAllocAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Blocks = new int[]{10, 20, 30, 40, 50, 100, 200};
            int[] RequestSize = new int[] { 14, 45, 198, 31 };

            while (true)
            {
                Console.WriteLine("Decida el algoritmo a usarse: ");
                Console.WriteLine("1. First Fit");
                Console.WriteLine("2. Next Fit");
                Console.WriteLine("3. Best Fit");
                Console.WriteLine("4. Worst Fit");
                Console.WriteLine("5. Quick Fit");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        FirstFit(Blocks, RequestSize);
                        break;
                    case 2:
                        NextFit(Blocks, RequestSize);
                        break;
                    case 3:
                        BestFit(Blocks, RequestSize);
                        break;
                    case 4:
                        WorstFit(Blocks, RequestSize);
                        break;
                    case 5:
                        QuickFit(RequestSize);
                        break;

                }
                Console.ReadLine();
            }


        }

        public static void FirstFit(int[] _blocks, int[] _requestSize){

        for (int i = 0; i < _requestSize.Length; i++)
            {
                for (int k = 0; k < _blocks.Length; k++)
                {
                    if (_blocks[k] >= _requestSize[i]) 
                    {
                        Console.WriteLine("Allocating Process {0} on Block {1}", _requestSize[i], _blocks[k]);
                        _blocks[k] -= _requestSize[i];
                        break;
                    }
                    else if (k == _blocks.Length - 1) 
                    {
                        Console.WriteLine("No block available for process {0}", _requestSize[i]);
                        break;
                    }
                }
            }
        }

        public static void NextFit(int[] _blocks, int[] _requestSize)
        {
            int position = 0;
            for (int i = 0; i < _requestSize.Length;)
            {
                int temp = 0;
                for (int j = position; j < _blocks.Length; j++)
                {
                    temp++;
                    if (_blocks[j] >= _requestSize[i])
                    {
                        Console.WriteLine("Allocating Process {0} on Block {1}", _requestSize[i], _blocks[j]);
                        _blocks[j] -= _requestSize[i];
                        if (j == _blocks.Length - 1)
                            position = 0;
                        else
                            position = j;
                        i++;
                        break;
                    }
                    if (j == _blocks.Length - 1 && _blocks[j] < _requestSize[i])
                        position = 0;
                    if (temp == 5)
                    {
                        Console.WriteLine("No block available for process {0}", _requestSize[i]);
                        i++;
                        break;
                    }
                }
            }

        }

        public static void BestFit(int[] _blocks, int[] _requestSize)
        {
            for (int i = 0; i < _requestSize.Length; i++)
            {
                for (int k = 0; k < _blocks.Length; k++)
                {
                    if (_blocks[k] >= _requestSize[i])
                    {
                        Console.WriteLine("Allocating Process {0} on Block {1}", _requestSize[i], _blocks[k]);
                        _blocks[k] -= _requestSize[i];
                        break;
                    }
                    else if (k == _blocks.Length - 1)
                    {
                        Console.WriteLine("No block available for process {0}", _requestSize[i]);
                        break;
                    }
                }
            }


        }

        public static void WorstFit(int[] _blocks, int[] _requestSize)
        {
            for (int i = 0; i < _requestSize.Length; i++)
            {
                for (int k = _blocks.Length-1; k >=0; k--)
                {
                    if (_blocks[k] >= _requestSize[i])
                    {
                        Console.WriteLine("Allocating Process {0} on Block {1}", _requestSize[i], _blocks[k]);
                        _blocks[k] -= _requestSize[i];
                        break;
                    }
                    else if (k == 0)
                    {
                        Console.WriteLine("No block available for process {0}", _requestSize[i]);
                        break;
                    }
                }
            }
        }

        public static void QuickFit(int[] _requestSize)
        {
            int[] Blocks1=new int[]{3,4,8};
            int[] Blocks2=new int[]{12,18,15};
            int[] Blocks3=new int[]{21,25,29};
            int[] Blocks4=new int[]{34,38,50};
            int[] Blocks5=new int[]{100,210,107};

            List<int[]>Buffer =new List<int[]>();
            Buffer.Add(Blocks1);
            Buffer.Add(Blocks2);
            Buffer.Add(Blocks3);
            Buffer.Add(Blocks4);
            Buffer.Add(Blocks5);
            int[] queue = new int[3];

            foreach (int r in _requestSize)
            {
                if(r>=51)
                {
                    queue = Buffer[4];
                }
                else if(r>=30&&r<=50)
                {
                    queue = Buffer[3];
                }
                else if(r>=16&&r<=29)
                {
                    queue = Buffer[2];
                }
                else if(r>=9&&r<=15)
                {
                    queue = Buffer[1];
                }
                else
                {
                    queue = Buffer[0];
                }
            
                for (int i = 0; i < queue.Length; i++)
                {
                    if (r <= queue[i])
                    {
                        Console.WriteLine("Allocating Process {0} on Block {1}", r,queue[i]);
                        break;
                    }
                }
            }
        }
    }
}
