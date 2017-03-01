/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 15.08.2016
 * Time: 19:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of FullRandomArrayStrategy.
	/// </summary>
	public class FullRandomArrayStrategy : ArrayStrategy
	{
		public FullRandomArrayStrategy() : base("Full random")
		{
		}
		
		override public void PrepareArray(int[] m, int size, int maxValue)
		{
			var rnd = new Random();
			for(int i = 0; i < size; ++i) {
				m[i] = rnd.Next(maxValue);
			}
		}
	}
}
