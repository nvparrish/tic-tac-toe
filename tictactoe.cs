class TicTacToe {
	///<summary>
	///The Main method of the tac-tac-toe game
	///</summary>
	///<param name="args">Command line arguments (unused) </param>
	///<returns>None</returns>
	static public void Main(string[] args) {
		System.Console.WriteLine("Welcome to the Tic Tac Toe game!");
		GameBoard board = new GameBoard();
		bool gameOver = false;
		int player = 0;
		char[] players = new char[]{'X', 'O'};
		do {
			board.Display();
			System.Console.Write(System.String.Format("{0}'s turn to choose a square (1-9): ", players[player]));
			try {
				ushort choice = System.Convert.ToUInt16(System.Console.ReadLine());
				while (!board.SetSquare(players[player], choice)) {
					System.Console.Write("Invalid chioce.  Choose another square (1-9): ");
					choice = System.Convert.ToUInt16(System.Console.ReadLine());
				}
				gameOver = board.IsGameOver();
				player = (player + 1) % players.Length;
			} catch (System.OverflowException e) {
				System.Console.WriteLine("Entry is not a valid number.");
			}
		} while (!gameOver);
		board.Display(); // Display one more time with the final board
		if (board.GetWinner() == ' ') {
			System.Console.WriteLine("Tie.  Good game.  Thanks for playing!");
		} else {
			System.Console.WriteLine("{0} wins.  Good game.  Thanks for playing!", board.GetWinner());
		}
	}
}
