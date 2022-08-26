open Chess
open Pieces
let pieces = 
  [| king(White, (0,0)) :> chessPiece; 
  rook(White, (2,2)) :> chessPiece;
  king(Black, (6,4)) :> chessPiece |]
let printPieceNMoves (elm : chessPiece) : unit = 
    printfn "%A, moves: %A" elm elm.availableMoves
Array.iter printPieceNMoves pieces
pieces[1].position <- Some (6,2)
printPieceNMoves pieces[1]
