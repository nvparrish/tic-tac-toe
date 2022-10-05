
class GameBoard {
	char [,] grid = new char [,] { { '1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'} };
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
			return true;
		} else {
			// Unavailable square
			return false;
		}
	}
}
