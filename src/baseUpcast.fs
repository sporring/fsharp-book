module Chess
type Color = White | Black
type Piece = King | Queen | Rook | Bishop | Knight | Pawn
[<AbstractClass>]
type chessPiece(color : Color, piece : Piece, position : int * int) =
  let mutable _position : (int * int) option = 
    chessPiece.condition position
  static member condition (row : int, col : int) : (int * int) option =
    if row < 0 || row > 7 || col < 0 || col > 7 
    then None
    else Some (row, col)
  member this.color = color
  member this.piece = piece
  member this.position 
    with get() = _position
    and set(p) = 
      match p with 
        None -> _position <- None 
        | Some p -> _position <- chessPiece.condition p
  override this.ToString() =
    match _position with
      Some p -> sprintf "%A %A at %A" color piece p 
      | None -> sprintf "%A %A not on the board" color piece
  abstract availableMoves : (int * int) list 