type Color = White | Black
type chessPiece (c : Color, p : int * int) =
  let condition (rank : int, file : int) : int * int =
    if rank < 0 || rank > 7 || file < 0 || file > 7 then
      failwith "Piece outside board."
    else
      (rank, file)
  let mutable _p = condition p
  member this.color = c
  member this.position
    with get () = _p
    and set (p) = _p <- condition p
let king = chessPiece (White, (0,0))
let rook = chessPiece (White, (2,0))
printfn "King at %A" king.position
printfn "Rook at %A" rook.position
king.position <- (1,0)
printfn "King moved to %A" king.position
