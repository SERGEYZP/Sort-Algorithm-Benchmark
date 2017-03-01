/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 15.08.2016
 * Time: 19:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of ArrayStrategy.
	/// </summary>
	abstract public class ArrayStrategy
	{
		string name;
		
		protected ArrayStrategy(string name)
		{
			this.name = name;
		}
		
		abstract public void PrepareArray(int[] m, int size, int maxValue);
		
		public string GetName()
		{
			return name;
		}
	}
}
