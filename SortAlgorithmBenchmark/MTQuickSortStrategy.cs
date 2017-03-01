/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 09.08.2016
 * Time: 18:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//#define MT_DEBUG

using System;
using System.Threading.Tasks;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of MTQuickSortStrategy.
	/// </summary>
	public class MTQuickSortStrategy : SortStrategy
	{
		const int TASKNUM = 8;
		
		public MTQuickSortStrategy() : base("MT (Many threads) Quick Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
		{
			SortContext.SetAffinity(0xF); //all Cores
			qsort(m, 0, size - 1, 0);
			SortContext.SetDefaultAffinity();
		}
		
		void qsort(int[] arr, long left, long right, int taskNum)
		{
//			Thread.CurrentThread.Priority = ThreadPriority.Highest; //огромные накладные расходы, будем надеется
			//что дочерние потоки будут иметь тот же приоритет, что и родительский
			bool fTL = false;
			long l = left, r = right;
			int piv = arr[(l + r) / 2]; // Опорным элементом для примера возьмём средний
			while(l <= r)
			{
				while(arr[l] < piv)
					l++;
				while(arr[r] > piv)
					r--;
				if(l <= r)
					Swap(ref arr[l++], ref arr[r--]);
			}
#if (MT_DEBUG)
			float middle = (float) (right - l) / (right - left); //в каком месте идет разделение массива
#endif
			if(taskNum < TASKNUM) {
				taskNum++;
				var taskL = new Task(() => qsort(arr, left, r, taskNum));
			
				if(left < r) {
					fTL = true;
					taskL.Start();
#if (MT_DEBUG)
					Console.Write("B{0:F2} ", middle);
#endif
				}
				if(right > l)
					qsort(arr, l, right, taskNum);
			
				if(fTL) {
					taskL.Wait();
#if (MT_DEBUG)
					Console.Write("S ");
#endif
				}
			} else {
				if (left < r)
					qsort(arr, left, r, taskNum);
				if (right > l)
					qsort(arr, l, right, taskNum);
			}
		}
	}
}
