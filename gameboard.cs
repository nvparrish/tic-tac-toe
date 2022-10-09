using System.Linq;

class GameBoard {
	char [,] grid = new char [,] { { '1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'} };
	bool gameOver = false;
	ushort roundCount = 0;
	char winner = ' ';

	/// <summary>
	/// Constructor for the GameBoard class
	/// </summary>
	public GameBoard() {
	}

	/// <summary>
	/// Method to display the grid.
	/// </summary>
	public void Display() {
		System.Console.WriteLine("{0}{1}{2}{3}{4}", grid[0,0], '|', grid[0,1], '|', grid[0,2]);
		System.Console.WriteLine("-----");
		System.Console.WriteLine("{0}{1}{2}{3}{4}", grid[1,0], '|', grid[1,1], '|', grid[1,2]);
		System.Console.WriteLine("-----");
		System.Console.WriteLine("{0}{1}{2}{3}{4}", grid[2,0], '|', grid[2,1], '|', grid[2,2]);
	}

	/// <summary>
	/// Method to restart the game
	/// </summary>
	public void Reset() {
		grid = new char [,] { { '1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'} };
	}

	/// <summary>
	/// A method to select the squre to be filled by the current player
	/// </summary>
	/// <param name="player">The character representing the current player</param>
	/// <param name="choice">A natural number representing the player's selection</param>
	/// <returns>True if the player's choice is available, flase if it is unavailable</returns>
	public bool SetSquare(char player, ushort choice) {
		try {
			int square = choice - 1;
			int row = square / 3;
			int col = square % 3;
			char core = (char)('1' + 3*row + col);
			if (core == grid[row,col]) {
				// Suitable to be replaced
				grid[row, col] = player;
				gameOver = CheckSquare(player, square);
				if (gameOver) {
					winner = player;
				}
				roundCount += 1;
				if (roundCount >= 3*3) {
					gameOver = true; // Tie
				}
				return true;
			} else {
				// Unavailable square
				return false;
			}
		} catch (System.IndexOutOfRangeException e) {
			// Return false for an invalid choice (out of bounds)
			return false;
		}
	}

	/// <summary>
	/// A function to check the square to see if there is a winning condition for this square. Only checks squares that
	/// are impacted by the current square choice
	/// </summary>
	/// <param name="player">The active player</param>
	/// <param name="square">The square to test</param>
	/// <returns></returns>
	bool CheckSquare(char player, int square)
	{
		return CheckRow(player, square/3) || CheckCol(player, square%3) || CheckDiagonal(player);
	}

	/// <summary>
	/// Method to check a specific row to see if the player has matched all columns
	/// </summary>
	/// <param name="player">A character representing the active player</param>
	/// <param name="row">The row to check</param>
	/// <returns>True if the player has all columns in the row, otherwise false</returns>
	bool CheckRow(char player, int row) {
		return (GridIterators.SliceRow(grid, row).ToList().TrueForAll(i => i.Equals(player)));
	}
	
	/// <summary>
	/// Method to check a specific column to see if the player matched all rows
	/// </summary>
	/// <param name="player">A character representing the active player</param>
	/// <param name="col">The column to check</param>
	/// <returns>True if the player has all rows in the column, otherwise false</returns>
	bool CheckCol(char player, int col) {
		return (GridIterators.SliceCol(grid, col).ToList().TrueForAll(i => i.Equals(player)));
	}

	/// <summary>
	/// Checks the diagonals to see if the player matches all along the diagonal
	/// </summary>
	/// <param name="player">A character representing the active player</param>
	/// <returns>True if the player matches either the diagonal or the cross diagonal</returns>
	bool CheckDiagonal(char player) {
		return (GridIterators.SliceDiag(grid).ToList().TrueForAll(i => i.Equals(player)))
			|| (GridIterators.SliceCrossDiag(grid).ToList().TrueForAll(i => i.Equals(player)));
	}

	/// <summary>
	/// Method to report if the game is over
	/// </summary>
	/// <returns>The game over state</returns>
	public bool IsGameOver() {
		return gameOver;
	}

	/// <summary>
	/// Method to get the winner of the game
	/// </summary>
	/// <returns>The character representing the winner if one exists, otherwise a space</returns>
	public char GetWinner() {
		return winner;
	}
}
