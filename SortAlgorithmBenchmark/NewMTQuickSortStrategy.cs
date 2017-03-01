/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 18.08.2016
 * Time: 20:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of NewMTQuickSortStrategy.
	/// </summary>
	public class NewMTQuickSortStrategy : SortStrategy
	{
		readonly int TASKNUM = 4;
		int taskNum;
		Object thisLock = new Object();
		
		public NewMTQuickSortStrategy() : base("MT (4 threads) Quick Sort...")
		{
			taskNum = 0;
		}
		
		public NewMTQuickSortStrategy(int taskNum)
		{
			name = string.Format("MT ({0} treads) Quick Sort...", taskNum);
			this.taskNum = 0;
			TASKNUM = taskNum;
		}		
		
		override public void Sort(int[] m, int size)
		{
			SortContext.SetAffinity(0xF); //all Cores
			qsort(m, 0, size - 1);
			SortContext.SetDefaultAffinity();
		}
		
		void qsort(int[] arr, long left, long right)
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
				var taskL = new Task(() => qsort(arr, left, r));
			
				if(left < r) {
					fTL = true;
					lock(thisLock) {
						++taskNum;
					}
					taskL.Start();
#if (MT_DEBUG)
					Console.Write("B{0:F2} ", middle);
#endif
				}
				if(right > l)
					qsort(arr, l, right);
			
				if(fTL) {
					taskL.Wait();
					lock(thisLock) {
						--taskNum;
					}
#if (MT_DEBUG)
					Console.Write("S ");
#endif
				}
			} else {
				if (left < r)
					qsort(arr, left, r);
				if (right > l)
					qsort(arr, l, right);
			}
		}
	}	
	
	
}
