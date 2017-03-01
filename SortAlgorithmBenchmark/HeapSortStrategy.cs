/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 13.08.2016
 * Time: 20:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of HeapSortStrategy.
	/// </summary>
	public class HeapSortStrategy : SortStrategy
	{
		public HeapSortStrategy() : base("Heap Sort...")
		{
		}

		override public void Sort(int[] m, int size)
		{
			long i;
			
			// строим пирамиду 
			for(i = size / 2 - 1; i >= 0; i--) {
				downHeap(m, i, size - 1);
			}
			
			// теперь m[0]...m[size - 1] пирамида 
			for(i = size - 1; i > 0; i--) {
				// меняем первый с последним 
				Swap(ref m[0], ref m[i]);
				// восстанавливаем пирамидальность m[0]...m[i - 1] 
				downHeap(m, 0, i - 1); 
			}
		}		
		
		void downHeap(int[] m, long k, long n) {
			//  процедура просеивания следующего элемента 
			//  До процедуры: m[k + 1]...a[n]  - пирамида 
			//  После:  m[k]...m[n]  - пирамида 
			int new_elem = m[k];
			long child;
			
			while(k <= n / 2) {  		// пока у m[k] есть дети 
				child = 2 * k;
				//  выбираем большего сына 
				if(child < n && m[child] < m[child + 1]) 
					child++;
				if(new_elem >= m[child])
					break;
				// иначе 
				m[k] = m[child]; 	// переносим сына наверх 
				k = child;
			}
			m[k] = new_elem;
		}
	}
}
