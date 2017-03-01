/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 07.08.2016
 * Time: 14:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of BubbleSortStrategy.
	/// </summary>
	public class BubbleSortStrategy : SortStrategy
	{
		public BubbleSortStrategy() : base ("Bubble Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
        {
        	bool end = false;
        	long j = 0;
        	while(!end) {
        		end = true;
        		for(long i = 0; i < size - 1 - j; ++i) {
        			if(m[i] > m[i + 1]) {
        				Swap(ref m[i], ref m[i + 1]);
        				end = false;
        			}
        		}
        		++j;
        	}
        }
	}
}
