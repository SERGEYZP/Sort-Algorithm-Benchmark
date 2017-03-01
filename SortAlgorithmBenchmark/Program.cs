using System;
using System.Diagnostics;

namespace SortAlgorithmBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
        	SetWindowSize(80, 75);
        	
            var stopwatch = new Stopwatch();

        	int size = 10000;
			size = 5000000;
			int maxValue = Int32.MaxValue;
//        	maxValue = 10; //max value in mass
        	const int repeat = 5; //repeat number of bench'es
        	const int columnWidth = 15;
            
			var sc = new SortContext(size, maxValue, repeat, true, columnWidth);
//			var sc = new SortContext(size, maxValue, repeat, false, columnWidth);
//			sc.Bench(new BubbleSortStrategy()); //пузырек slow
//			sc.Bench(new ShakeSortStrategy()); //коктельная slow
//			sc.Bench(new PairSortStrategy()); //чет-нечет slow
//			sc.Bench(new SelectSortStrategy()); //сортировка выбором medium
//			sc.Bench(new HeapSortStrategy()); //пирамида
//			sc.Bench(new CombSortStrategy()); //расческа
//			sc.Bench(new QuickSortStrategy()); //быстрая
			sc.Bench(new MTQuickSortStrategy()); //быстрая многопотоковая
			sc.Bench(new NewMTQuickSortStrategy()); //быстрая многопотоковая
			
            Console.WriteLine("Done...");
            Console.ReadKey();
        }
        
        static void SetWindowSize(int column, int row)
        {
        	Console.SetBufferSize(column, row);
        	Console.SetWindowSize(column, row);
        }
    }
}