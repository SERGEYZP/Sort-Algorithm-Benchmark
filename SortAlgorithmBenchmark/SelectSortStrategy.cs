/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 20.08.2016
 * Time: 18:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of SelectSortStrategy.
	/// </summary>
	public class SelectSortStrategy : SortStrategy
	{
		public SelectSortStrategy() : base("Select Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
		{
			int min, k;
			for(int i = 0; i < size; i++) {
				min = m[i];
				k = i;
				for(int j = i + 1; j < size; j++) {
					if(m[j] < min) {
						min = m[j];
						k = j;
					}
				}
				m[k] = m[i]; m[i] = min; //swap
			}
		}
	}
}
