/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 07.08.2016
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of CombSortStrategy.
	/// </summary>
	public class CombSortStrategy : SortStrategy
	{
		public CombSortStrategy() : base("Comb Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
        {
        	bool end = false;
        	long j = 0;
        	const float divFactor = 1.2473309f;
        	long step = size;
        	while(!end) {
        		step = (long)(step / divFactor);
        		if(step < 1) {
        			step = 1;
        		}
        		if(step == 1) {
        			end = true;
        		}
        		for(long i = 0; i + step < size - j; ++i) {
        			if(m[i] > m[i + step]) {
        				Swap(ref m[i], ref m[i + step]);
        				end = false;
        			}
        		}
        		if(step == 1) {
        			++j;
        		}
        	}
        }
	}
}
