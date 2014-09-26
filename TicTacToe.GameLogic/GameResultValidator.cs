namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        // O-X
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            return CheckGameResult(board);
        }
        private GameResult CheckGameResult(string boardAsString)
        {
            var board = new char[3, 3];
            for (int i = 0; i < boardAsString.Length; i++)
            {
                int row = i / 3;
                int col = i % 3;
                board[row, col] = boardAsString[i];
            }

            //// TODO: Implement Check if the game is won by X or O player

            // horizontal check
            for (int row = 0; row < board.GetLength(0); row++)
            {
                var wonBy = string.Empty;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    wonBy += board[row, col];
                }

                if (wonBy.Contains("XXX"))
                {
                    return GameResult.WonByX;
                }
                else if (wonBy.Contains("OOO"))
                {
                    return GameResult.WonByO;
                }
            }

            // vertical check
            for (int col = 0; col < board.GetLength(1); col++)
            {
                var wonBy = string.Empty;

                // check for X won
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    wonBy += board[row, col];
                }

                if (wonBy.Contains("XXX"))
                {
                    return GameResult.WonByX;
                }
                else if (wonBy.Contains("OOO"))
                {
                    return GameResult.WonByO;
                }
            }

            // diagonals check
            // top left to bottom right check
            var topLeftBottomRightDiagonal = string.Empty;
            topLeftBottomRightDiagonal += board[0, 0] + board[1, 1] + board[2, 2];

            if (topLeftBottomRightDiagonal.Contains("XXX"))
            {
                return GameResult.WonByX;
            }
            else if (topLeftBottomRightDiagonal.Contains("OOO"))
            {
                return GameResult.WonByO;
            }

            // top left to bottom right check
            var topRgightBottomLeftDiagonal = string.Empty;
            topRgightBottomLeftDiagonal += board[0, 0] + board[1, 1] + board[2, 2];

            if (topRgightBottomLeftDiagonal.Contains("XXX"))
            {
                return GameResult.WonByX;
            }
            else if (topRgightBottomLeftDiagonal.Contains("OOO"))
            {
                return GameResult.WonByO;
            }

            if (!boardAsString.Contains("-"))
            {
                return GameResult.Draw;
            }
            else
            {
                return GameResult.NotFinished;
            }
        }
    }
}
