type Color = White | Black
type Piece = King | Queen | Rook | Bishop | Knight | Pawn
type chessPiece(color : Color, piece : Piece, position : int * int) =
  let condition (rank : int, file : int) : int * int =
    if rank < 0 || rank > 7 || file < 0 || file > 7 then
      failwith "Piece outside board."
    else
      (rank, file)
  let mutable _position = condition position
  member this.color = color
  member this.piece = piece
  member this.position
    with get() = _position
    and set(p) = _position <- condition p
  override this.ToString() =
    sprintf "%A at %A" piece _position
type king(color : Color, position : int * int) =
   inherit chessPiece(color, King, position)
type rook(color : Color, position : int * int) =
   inherit chessPiece(color, Rook, position)

let pieces = [| king(White, (0,0)) :> chessPiece; rook(White, (2,0))  :> chessPiece|]
printfn "%A" pieces
pieces.[0].position <- (1,0)
printfn "%A" pieces