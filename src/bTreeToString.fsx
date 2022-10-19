type element = Value of float | Mul | Plus | Minus | Div
// A binary tree
type bTree = Leaf of element | Node of element * bTree * bTree
let rec toString (tab: string) (t:bTree) : string =
  match t with
    Leaf v -> tab+(string v)+"\n"
    | Node (op, a, b) -> 
      tab + (string op) + "\n"
      + (toString (tab + "  ") a)
      + (toString (tab + "  ") b) 

/// The tree representation of 1/(3+5)
let expr: bTree = Node (Div, Leaf (Value 1.0), Node (Plus, Leaf (Value 3.0), Leaf (Value 5.0)))
printf "%s" (toString "" expr)
