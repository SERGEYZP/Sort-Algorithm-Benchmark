/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 13.08.2016
 * Time: 20:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of SortStrategy.
	/// </summary>
	abstract public class SortStrategy
	{
		protected string name;
		
		protected SortStrategy()
		{
		}
		
		protected SortStrategy(string name)
		{
			this.name = name;
		}
		
		abstract public void Sort(int[] m, int size);
		
		public void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}
		
		public string GetName()
		{
			return name;
		}
	}
}
