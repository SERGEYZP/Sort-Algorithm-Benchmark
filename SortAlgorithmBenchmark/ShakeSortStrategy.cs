/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 20.08.2016
 * Time: 18:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of ShakeSortStrategy.
	/// </summary>
	public class ShakeSortStrategy : SortStrategy
	{
		public ShakeSortStrategy() : base("Shake (Coctail) Sort...")
		{
		}
		
		override public void Sort(int[] m, int size)
        {
        	bool end = false;
        	int l = 0;
        	int r = size - 1;
        	int k = 0;
        	while(!end) {
        		end = true;
        		for(int i = l; i < r ; ++i) {
        			if(m[i] > m[i + 1]) {
        				Swap(ref m[i], ref m[i + 1]);
        				k = i;
        				end = false;
        			}
        		}
        		r = k;
        		for(int i = r; i > l; --i) {
        			if(m[i] < m[i - 1]) {
        				Swap(ref m[i], ref m[i - 1]);
        				k = i;
        				end = false;
        			}
        		}
        		l = k;
        	}
        }
	}
}
