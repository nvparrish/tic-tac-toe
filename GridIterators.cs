using System.Collections.Generic;

public static class GridIterators {

	public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
	{
		for (var i = 0; i < array.GetLength(1); i++)
		{
			yield return array[row, i];
		}
	}


	public static IEnumerable<T> SliceCol<T>(this T[,] array, int col)
	{
		for (var i = 0; i < array.GetLength(0); i++)
		{
			yield return array[i, col];
		}
	}

	public static IEnumerable<T> SliceDiag<T>(this T[,] array)
	{
		for (var i = 0; i < System.Math.Min(array.GetLength(0), array.GetLength(1)); i++)
		{
			yield return array[i, i];
		}
	}

	public static IEnumerable<T> SliceCrossDiag<T>(this T[,] array)
	{
		for (var i = 0; i < System.Math.Min(array.GetLength(0), array.GetLength(1)); i++)
		{
			yield return array[i, array.GetLength(0)-1-i];
		}
	}


}
