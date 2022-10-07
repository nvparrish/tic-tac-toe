
class GameBoard {
	char [,] grid = new char [,] { { '1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'} };
	bool gameOver = false;
	ushort roundCount = 0;
	char winner = ' ';
	public GameBoard() {
	}
	public void Display() {
		System.Console.WriteLine("{0}{1}{2}{3}{4}", grid[0,0], '|', grid[0,1], '|', grid[0,2]);
		System.Console.WriteLine("-----");
		System.Console.WriteLine("{0}{1}{2}{3}{4}", grid[1,0], '|', grid[1,1], '|', grid[1,2]);
		System.Console.WriteLine("-----");
		System.Console.WriteLine("{0}{1}{2}{3}{4}", grid[2,0], '|', grid[2,1], '|', grid[2,2]);
	}
	public void Reset() {
		grid = new char [,] { { '1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'} };
	}
	public bool SetSquare(char player, ushort choice) {
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
	}
	bool CheckSquare(char player, int square)
	{
		return CheckRow(player, square/3) || CheckCol(player, square%3) || CheckDiagonal(player, square);
	}

	bool CheckRow(char player, int row) {
		return (grid[row,0] == player && 
			grid[row,1] == player && 
			grid[row,2] == player);
	}
	
	bool CheckCol(char player, int col) {
		return (grid[0,col] == player && 
			grid[1,col] == player && 
			grid[2,col] == player);
	}

	bool CheckDiagonal(char player, int square) {
		if (square == 0 || square == 8){
			return (grid[0,0] == player && 
				grid[1,1] == player &&
				grid[2,2] == player);
		} else if (square == 2 || square == 6) {
			return (grid[0,2] == player && 
				grid[1,1] == player &&
				grid[2,0] == player);
		} else if (square == 4) {
			return ((grid[0,0] == player && 
				grid[1,1] == player &&
				grid[2,2] == player) || 
				(grid[0,2] == player && 
				grid[1,1] == player &&
				grid[2,0] == player));

		}
		return false;
	}

	public bool IsGameOver() {
		return gameOver;
	}

	public char GetWinner() {
		return winner;
	}
}
