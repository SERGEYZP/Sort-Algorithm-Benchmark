/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 15.08.2016
 * Time: 20:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of EqualElementsArrayStrategy.
	/// </summary>
	public class EqualElementsArrayStrategy : ArrayStrategy
	{
		public EqualElementsArrayStrategy() : base("Equal elements")
		{
		}
		
		override public void PrepareArray(int[] m, int size, int maxValue)
		{
			for(int i = 0; i < size; ++i) {
				m[i] = 4;
			}
		}
	}
}
