/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 16.08.2016
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SortAlgorithmBenchmark
{
	/// <summary>
	/// Description of Screen.
	/// </summary>
	public class Screen
	{
		int x, y;
		int columnWidth;
		int rowHeight;
		int screenWidth;
		
		public Screen(int screenWidth, int columnWidth, int rowHeight)
		{
			x = 0; y = 0;
			this.screenWidth = screenWidth;
			this.columnWidth = columnWidth;
			this.rowHeight = rowHeight;
		}
		
		public void WriteLine(string text, long param)
		{
			Console.SetCursorPosition(x, y++);
			Console.WriteLine(text, param);
		}
		
		public void WriteLine(string text)
		{
			Console.SetCursorPosition(x, y++);
			Console.WriteLine(text);
		}
		
		public void SetRedColor()
		{
			Console.ForegroundColor = ConsoleColor.Red;
		}
		
		public void SetGreenColor()
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}
		
		public void SetDarkYellowColor()
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
		}
		
		public void SetGrayColor()
		{
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		
		public void Write(string text, long param)
		{
			Console.Write(text, param);
		}
		
		public void Write(string text)
		{
			Console.Write(text);
		}
		
		public void SetNextColumn()
		{
			x += columnWidth;
			y = y - (rowHeight + 1);
		}
		
		public void SetFirstColumn()
		{
			x = 0;
			y = y + (rowHeight + 1);
		}
		
		public void WriteRowDelimeter()
		{
			for(int i = 0; i < screenWidth; ++i) {
				Console.Write("-");
			}
			WriteLine("");
		}
	}
}
