type Color = White | Black
type chessPiece(c : Color) =
  member this.color = c
  static member find (board: chessPiece option [,]) (piece : chessPiece) =
    let rec find (rank : int) (file : int) =
      match (rank, file) with
        (-1, _) -> None
        | (rank, -1) -> find (rank - 1) 7
        | (rank, file) -> 
          if board[rank,file] = Some piece then 
            Some (rank,file)
          else
            find rank (file - 1)

    find 7 7
  member this.position (board: chessPiece option [,]) = 
    chessPiece.find board this

let board = Collections.Array2D.create<chessPiece option> 8 8 None
let king = chessPiece(White)
let rook = chessPiece(White)
board[0,0] <- Some king
match king.position(board) with Some _p -> printfn "King at %A" _p | None -> printfn "King not on board"
match rook.position(board) with Some _p -> printfn "Rook at %A" _p | None -> printfn "Rook not on board"
board[1,0] <- Some king
match king.position(board) with Some _p -> printfn "King moved to %A" _p | None -> printfn "King not on board"
