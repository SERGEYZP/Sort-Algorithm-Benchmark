/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 15.08.2016
 * Time: 20:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of DescendingSortedArrayStrategy.
	/// </summary>
	public class DescendingSortedArrayStrategy : ArrayStrategy
	{
		public DescendingSortedArrayStrategy() : base("D-Sorted array")
		{
		}

		override public void PrepareArray(int[] m, int size, int maxValue)
		{
			for(int i = 0; i < size; ++i) {
				m[i] = --size;
			}
		}
	}
}
