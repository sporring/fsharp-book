module Pieces
open Chess
type Chess.chessPiece with 
  static member validPostions (row : int, col : int) (lst : (int * int) list) : (int * int) list =
    lst
    // check whether absolution positions is on the board
    |> List.map (fun (dr, df) -> chessPiece.condition (row+dr, col+df))
    // take valid position and strip option type.
    |> List.fold (fun acc elm -> 
         match elm with None -> acc | Some p -> acc @ [p]) []
type king(color : Color, position : int * int) =
  inherit chessPiece(color, King, position)
  override this.availableMoves = 
    match this.position with
      None -> []
      | Some (row,col) -> 
        // king can move 1 step (N, NE, E, SE, S, SW, W, NW)
        [(-1,0);(-1,1);(0,1);(1,1);(1,0);(1,-1);(0,-1);(-1,-1)]
        |> chessPiece.validPostions (row,col) 
type rook(color : Color, position : int * int) =
  inherit chessPiece(color, Rook, position)
  override this.availableMoves = 
    match this.position with
      None -> []
      | Some (row,col) -> 
        // rook can move horisontally and vertically
        let indices = [1;2;3;4;5;6;7]
        let south = List.map (fun elm -> (elm,0)) indices
        let north = List.map (fun elm -> (-elm,0)) indices
        let east = List.map (fun elm -> (0,elm)) indices
        let west = List.map (fun elm -> (0,-elm)) indices
        (south @ north @ east @ west)
        |> chessPiece.validPostions (row,col)