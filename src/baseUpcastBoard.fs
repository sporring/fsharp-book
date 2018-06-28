module Chess
type Color = White | Black
type Piece = King | Queen | Rook | Bishop | Knight | Pawn
type Position = int * int
[<AbstractClass>]
type chessPiece(color : Color, piece : Piece, position : Position) =
  let mutable _position : Position option = 
    chessPiece.onBoardSift position
  static member onBoardSift pos : Position option =
    let (rank, file) = pos // location on board are called rank and file
    if rank < 0 || rank > 7 || file < 0 || file > 7 
    then None
    else Some (rank, file)
  member this.color = color
  member this.piece = piece
  member this.position 
    with get() = _position
    and set(p) = 
      match p with 
        None -> _position <- None 
        | Some p -> _position <- chessPiece.onBoardSift p
  override this.ToString() =
    match _position with
      Some p -> sprintf "%A %A at %A" color piece p 
      | None -> sprintf "%A %A not on the board" color piece
  abstract availableMoves : Board -> Position list * (chessPiece option list)
and Board = chessPiece [] // Use "and" to define mutually recursive types