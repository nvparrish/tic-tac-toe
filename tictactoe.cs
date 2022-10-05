class TicTacToe {
	static public void Main(string[] args) {
		System.Console.WriteLine("Welcome to the Tic Tac Toe game!");
		GameBoard board = new GameBoard();
		bool gameOver = false;
		int player = 0;
		char[] players = new char[]{'X', 'O'};
		while (!gameOver) {
			board.Display();
			System.Console.Write(System.String.Format("{0}'s turn to choose a square (1-9): ", players[player]));
			ushort choice = System.Convert.ToUInt16(System.Console.ReadLine());
			while (!board.SetSquare(players[player], choice)) {
				System.Console.Write("Invalid chioce.  Choose another square (1-9): ");
				choice = System.Convert.ToUInt16(System.Console.ReadLine());
			}
			// TODO: Check for win / loss
			player = (player + 1) % players.Length;
			gameOver = true;
		}
	}
}
