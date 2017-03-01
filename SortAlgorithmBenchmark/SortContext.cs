/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 07.08.2016
 * Time: 14:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of SortContext.
	/// </summary>
	public class SortContext
	{
		bool checkAlgorithm;
		int[] m;
		int size;
		int maxValue;
		int repeat;
		readonly static int CPUmask = 0x8;
		Stopwatch stopwatch;
		Screen scr;
		List<ArrayStrategy> arrayStrategyList;
		
		public SortContext(int size, int maxValue, int repeat, bool checkAlgorithm, int columnWidth)
		{
			m = new int[size];
			this.size = size;
			this.maxValue = maxValue;
			this.repeat = repeat;
			this.checkAlgorithm = checkAlgorithm;
			stopwatch = new Stopwatch();
			scr = new Screen(80, columnWidth, repeat);
			
			arrayStrategyList = new List<ArrayStrategy>();
			arrayStrategyList.Add(new FullRandomArrayStrategy());
			arrayStrategyList.Add(new FivePercentArrayStrategy());
			arrayStrategyList.Add(new DescendingSortedArrayStrategy());
			arrayStrategyList.Add(new AscendingSortedArrayStrategy());
			arrayStrategyList.Add(new EqualElementsArrayStrategy());
			
			SetDefaultAffinity(); // Uses the fourth Core or Processor for the Test

            scr.Write("Mass size: {0}    ", size);
            scr.Write("Repeat number: {0}    ", repeat);
            scr.Write("Max value in mass: {0}", maxValue);
            scr.WriteLine("");
//			Console.WriteLine("Mass size: " + size + "\tRepeat number: " + repeat + "\tMax value in mass: " + maxValue);
		}

		static public void SetDefaultAffinity()
		{
			Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(CPUmask); // Set Core (or Cores) or Processor (or Processors) for the Test
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; // Prevents "Normal" processes from interrupting Threads
            Thread.CurrentThread.Priority = ThreadPriority.Highest; // Prevents "Normal" Threads from interrupting this thread
		}		
		
		static public void SetAffinity(int CPUmask)
		{
			Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(CPUmask); // Set Core (or Cores) or Processor (or Processors) for the Test
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; // Prevents "Normal" processes from interrupting Threads
            Thread.CurrentThread.Priority = ThreadPriority.Highest; // Prevents "Normal" Threads from interrupting this thread
		}
		
		bool IsCorrectSortAlgorithm(SortStrategy sortStrategy, ArrayStrategy arrayStrategy)
		{
			scr.SetDarkYellowColor();
			scr.Write("Test Algorithm for correctness: ");
			arrayStrategy.PrepareArray(m, size, maxValue);
			sortStrategy.Sort(m, size);
			if(!IsAscendingOrderedArray()) {
				scr.SetRedColor();
				scr.Write("Not Correct Sorting.");
				scr.WriteLine("");
				scr.SetGrayColor();
				return false;
			}
			scr.SetGreenColor();
			scr.Write("Done.");
			scr.WriteLine("");
			scr.SetGrayColor();
			return true;
		}
		
		public void Bench(SortStrategy sortStrategy)
		{
			scr.WriteRowDelimeter();
			scr.SetRedColor();
			scr.WriteLine(sortStrategy.GetName());
			scr.SetGrayColor();
			
			if(checkAlgorithm) {
				if(!IsCorrectSortAlgorithm(sortStrategy, new FullRandomArrayStrategy())) {
//				if(!IsCorrectSortAlgorithm(sortStrategy, new DescendingSortedArrayStrategy())) {
					return;
				}
			}
			
			foreach(var arrayStrategy in arrayStrategyList) {
				scr.WriteLine(arrayStrategy.GetName());
				for(int i = 0; i < repeat; ++i) {
					arrayStrategy.PrepareArray(m, size, maxValue);
	                stopwatch.Reset();
	                stopwatch.Start();
	                sortStrategy.Sort(m, size);
	                stopwatch.Stop();
	                scr.WriteLine("{0,6}ms", stopwatch.ElapsedMilliseconds);
	            }
				scr.SetNextColumn();
			}
			scr.SetFirstColumn();
		}
		
		bool IsAscendingOrderedArray()
        {
			long i = size;
        	while(--i != 0) {
        		if(m[i] < m[i - 1]) {
        			return false;
        		}
        	}
        	return true;
        }
	}
}
