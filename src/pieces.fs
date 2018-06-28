module Pieces
open Chess
/// A king is a chessPiece which moves 1 square in any direction
type king(col : Color) =
  inherit chessPiece(col)
  override this.nameOfType = "king"
  // king has runs of 1 in 8 directions: (N, NE, E, SE, S, SW, W, NW)
  override this.candiateRelativeMoves =
      [[(-1,0)];[(-1,1)];[(0,1)];[(1,1)];
      [(1,0)];[(1,-1)];[(0,-1)];[(-1,-1)]]
/// A rook is a chessPiece which moves horisontally and vertically
type rook(col : Color) =
  inherit chessPiece(col)
  // rook can move horisontally and vertically
  // Make a list of relative coordinate lists. We consider the
  // current position and try all combinations of relative moves
  // (1,0); (2,0) ... (7,0); (-1,0); (-2,0); ...; (0,-7).
  // Some will be out of board, but will be assumed removed as
  // illegal moves.
  // A list of functions for relative moves
  let indToRel = [
    fun elm -> (elm,0); // South by elm
    fun elm -> (-elm,0); // North by elm
    fun elm -> (0,elm); // West by elm
    fun elm -> (0,-elm) // East by elm
    ]
  // For each function in indToRel, we calculate List.map f [1..7].
  // swap converts (List.map fct indices) to (List.map indices fct).
  let swap f a b = f b a
  override this.candiateRelativeMoves =
    List.map (swap List.map [1..7]) indToRel (*//§\label{chessPieceSwapApp}§*)
  override this.nameOfType = "rook"
