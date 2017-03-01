/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 07.08.2016
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of PairSortStrategy.
	/// </summary>
	public class PairSortStrategy : SortStrategy
	{
		public PairSortStrategy() : base("Pair Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
        {
			if(size % 2 != 0)
				new NotImplementedException();
        	bool end = false;
        	while(!end) {
        		end = true;
        		for(long i = 0; i < size - 1; i += 2) {
        			if(m[i] > m[i + 1]) {
        				Swap(ref m[i], ref m[i + 1]);
        				end = false;
        			}
        		}
				for(long i = 1; i < size - 1; i += 2) {
        			if(m[i] > m[i + 1]) {
        				Swap(ref m[i], ref m[i + 1]);
        				end = false;
        			}
        		}
        	}
        }
	}
}
