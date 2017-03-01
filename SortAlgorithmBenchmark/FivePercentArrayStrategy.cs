/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 15.08.2016
 * Time: 19:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of FivePercentArrayStrategy.
	/// </summary>
	public class FivePercentArrayStrategy : ArrayStrategy
	{
		public FivePercentArrayStrategy() : base("5% random")
		{
		}
		
		override public void PrepareArray(int[] m, int size, int maxValue)
		{
			var rnd = new Random();
			for(int i = 0; i < size * 0.05; ++i) {
				m[rnd.Next(size - 1)] = rnd.Next(maxValue);
			}
		}
	}
}
