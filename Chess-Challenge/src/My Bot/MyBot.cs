using ChessChallenge.API;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        
        int scoreMult = board.IsWhiteToMove ? 1 : -1 ;
        decimal bestEval = decimal.MinValue;
        Move bestMove = moves[0];
        foreach (Move move in moves)
        {
            // Always play checkmate in one
            if (MoveIsCheckmate(board, move))
            {
                return move;
            }
            board.MakeMove(move);
            decimal eval = Evaluate(board) * scoreMult;

            if (eval > bestEval)
            {
                bestEval = eval;
                bestMove = move;
            }


            board.UndoMove(move);
    
        }
        return bestMove;
    }

    public decimal Evaluate(Board board)
    {
        // Call python script to evaluate the board
        return 0;
    }


    private bool MoveIsCheckmate(Board board, Move move)
        {
            board.MakeMove(move);
            bool isMate = board.IsInCheckmate();
            board.UndoMove(move);
            return isMate;
        }
}