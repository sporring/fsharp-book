open Chess
open Pieces
let board : Board = 
  [| king(White, (0,0)) :> chessPiece; 
  rook(White, (1,1)) :> chessPiece;
  king(Black, (4,1)) :> chessPiece |]
let printPieceNMoves (elm : chessPiece) : unit = 
    printfn "%A, moves: %A" elm (elm.availableMoves board)
Array.iter printPieceNMoves board
printfn "Moving %A" board.[1]
board.[1].position <- Some (5,2)
Array.iter printPieceNMoves board