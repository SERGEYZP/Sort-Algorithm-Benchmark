/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 15.08.2016
 * Time: 19:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of AscendingSortedArrayStrategy.
	/// </summary>
	public class AscendingSortedArrayStrategy : ArrayStrategy
	{
		public AscendingSortedArrayStrategy() : base("A-Sorted array")
		{
		}

		override public void PrepareArray(int[] m, int size, int maxValue)
		{
			for(int i = 0; i < size; ++i) {
				m[i] = i;
			}
		}		
	}
}
