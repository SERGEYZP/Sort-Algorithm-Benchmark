/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 07.08.2016
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of QuickSortStrategy.
	/// </summary>
	public class QuickSortStrategy : SortStrategy
	{
		public QuickSortStrategy() : base("Quick Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
		{
			qsort(m, 0, size - 1);
		}
		
		void qsort (int[] arr, long left, long right)
		{
			long l = left, r = right;
			int piv = arr[(l + r) / 2]; // Опорным элементом для примера возьмём средний
			while (l <= r)
			{
				while (arr[l] < piv)
					l++;
				while (arr[r] > piv)
					r--;
				if (l <= r)
					Swap (ref arr[l++], ref arr[r--]);
			}
			if (left < r)
				qsort (arr, left, r);
			if (right > l)
				qsort (arr, l, right);
		}
	}
}
