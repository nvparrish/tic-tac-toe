using System.Collections.Generic;

/// <summary>
/// A public static class to hold iterators for the tic tac toe game
/// </summary>
public static class GridIterators {

	/// <summary>
	/// Gets an iterator to give a slice of the row
	/// </summary>
	/// <param name="array">The 2-D array to slice</param>
	/// <param name="row">The row to slice</param>
	/// <typeparam name="T">The type of data in the 2-D array</typeparam>
	/// <returns>Yields the entries in the row</returns>
	public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
	{
		for (var i = 0; i < array.GetLength(1); i++)
		{
			yield return array[row, i];
		}
	}


	/// <summary>
	/// Gets an iterator to give a slice of the column
	/// </summary>
	/// <param name="array">The 2-D array to slice</param>
	/// <param name="col">The column to slice</param>
	/// <typeparam name="T">The type of data in the 2-D array</typeparam>
	/// <returns>Yields the entries in the column</returns>
	public static IEnumerable<T> SliceCol<T>(this T[,] array, int col)
	{
		for (var i = 0; i < array.GetLength(0); i++)
		{
			yield return array[i, col];
		}
	}

	/// <summary>
	/// Gets an iterator to give a diagonal slice
	/// </summary>
	/// <param name="array">The 2-D array to slice</param>
	/// <typeparam name="T">The type of data in the 2-D array</typeparam>
	/// <returns>Yields the entries in the diagonal</returns>
	public static IEnumerable<T> SliceDiag<T>(this T[,] array)
	{
		for (var i = 0; i < System.Math.Min(array.GetLength(0), array.GetLength(1)); i++)
		{
			yield return array[i, i];
		}
	}

	/// <summary>
	/// Gets an iterator to give a slice of the cross diagonal
	/// </summary>
	/// <param name="array">The 2-D array to slice</param>
	/// <typeparam name="T">The type of data in the 2-D array</typeparam>
	/// <returns>Yields the entries in the cross diagonal</returns>
	public static IEnumerable<T> SliceCrossDiag<T>(this T[,] array)
	{
		for (var i = 0; i < System.Math.Min(array.GetLength(0), array.GetLength(1)); i++)
		{
			yield return array[i, array.GetLength(0)-1-i];
		}
	}

}
