module Pieces
open Chess
type Chess.chessPiece with 
  static member isVacant (board : Board) (p : Position) : bool =
    let piece = chessPiece.getPieceAt board p
    piece.IsNone
  static member relativeToAbsolute (pos : Position) (lst : Position list) : Position list =
    let addPair (a : int, b : int) (c : int, d : int) : Position = (a+c,b+d)
    // Add origin and delta positions
    List.map (addPair pos) lst
    // Choose absolute positions that are on the board
    |> List.choose chessPiece.onBoardSift
  static member getPieceAt (board : Board) (pos : Position) : chessPiece option =
      try
        Some (Array.find (fun elm -> elm.position = Some pos) board)
      with
        _ -> None
  static member getVacantNOccupied (board : Board) (run : Position list) : (Position list * (chessPiece option)) =
    try
      let idx = List.findIndex (fun elm -> not (chessPiece.isVacant board elm)) run // First isVacant then not
      let piece = chessPiece.getPieceAt board (run.[idx])
      if idx = 0
      then ([], piece)
      else (run.[..(idx-1)], piece)
    with
      _ -> (run, None) // outside the board
  member this.isOpponent (piece : chessPiece option) : bool =
      match piece with 
        None -> false
        | Some p -> p.color <> this.color
  member this.getVacentNOpponents (board : Board) (lstlst : Position list list) : (Position list * chessPiece option list)  =
    match this.position with
      None -> ([],[])
      | Some pos -> 
        let convertNWrap = (chessPiece.relativeToAbsolute pos) >> (chessPiece.getVacantNOccupied board)
        let vacantPieceLists = List.map convertNWrap lstlst
        // Extract and merge lists of vacant squares
        let vacant = List.collect fst vacantPieceLists
        // Extract and merge lists of first obstruction pieces and filter out own pieces
        let opponent = 
          vacantPieceLists
          |> List.map snd 
          |> List.filter this.isOpponent
        (vacant, opponent)
type rook(col : Color, pos : Position) =
  inherit chessPiece(col, Rook, pos)
  override this.availableMoves (board : Board) = 
    // rook can move horisontally and vertically
    let indices = [1;2;3;4;5;6;7]
    let indToRelativeCoordinate = [
      fun elm -> (elm,0);
      fun elm -> (-elm,0);
      fun elm -> (0,elm);
      fun elm -> (0,-elm)
    ]
    // Make a list of relative coordinate lists: runs to be checked
    let proposedListofRuns = List.map (fun fct -> List.map fct indices) indToRelativeCoordinate
    // Analyze runs and return (list of vacant available positions, and opponents pieces in the vicinity)
    this.getVacentNOpponents board proposedListofRuns
type king(col : Color, pos : Position) =
  inherit chessPiece(col, King, pos)
  override this.availableMoves (board : Board)= 
    // king can move runs of 1 in all directions: (N, NE, E, SE, S, SW, W, NW)
    let proposedListofRuns = [[(-1,0)];[(-1,1)];[(0,1)];[(1,1)];[(1,0)];[(1,-1)];[(0,-1)];[(-1,-1)]]
    this.getVacentNOpponents board proposedListofRuns