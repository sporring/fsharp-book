module Pieces
open Chess
/// A king moves 1 square in any direction
type king(col : Color) =
  inherit chessPiece(col)
  // A king has runs of length 1 in 8 directions:
  //   (N, NE, E, SE, S, SW, W, NW)
  override this.candidateRelativeMoves =
      [[(-1,0)];[(-1,1)];[(0,1)];[(1,1)];
      [(1,0)];[(1,-1)];[(0,-1)];[(-1,-1)]]
  override this.nameOfType = "king"
/// A rook moves horizontally and vertically
type rook(col : Color) =
  inherit chessPiece(col)
  // A rook can move horizontally and vertically
  // Make a list of relative coordinate lists. We consider the
  // current position and try all combinations of relative
  // moves (1,0); (2,0) ... (7,0); (-1,0); (-2,0); ...; (0,-7).
  // Some will be out of board, but will be assumed removed as
  // illegal moves.
  // A list of functions for relative moves
  let indToRel = [
    fun elm -> (elm,0); // South by elm
    fun elm -> (-elm,0); // North by elm
    fun elm -> (0,elm); // West by elm
    fun elm -> (0,-elm) // East by elm
    ]
  // For each function f in indToRel, we calculate
  //   List.map f [1..7].
  override this.candidateRelativeMoves =
    List.map (fun e -> List.map e [1..7]) indToRel (*//§\label{chessPieceSwapApp}§*)
  override this.nameOfType = "rook"
