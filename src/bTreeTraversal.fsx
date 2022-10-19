type element = Value of float | Mul | Plus | Minus | Div
type bTree = Leaf of element | Node of element * bTree * bTree

/// Prefix traversal of a binary tree
let rec prefix (t: bTree) : (element list) =
  match t with
    Leaf e -> [e]
    | Node (e, left, right) ->
      e :: (prefix left) @ (prefix right)
/// Infix traversal of a binary tree
let rec infix (t: bTree) : (element list) =
  match t with
    Leaf e -> [e]
    | Node (e, left, right) ->
      (infix left) @ [e] @ (infix right)
/// Postfix traversal of a binary tree
let rec postfix (t: bTree) : (element list) =
  match t with
    Leaf e -> [e]
    | Node (e, left, right) ->
      (postfix left) @ (postfix right) @ [e]

let expr: bTree = Node (Div, Leaf (Value 1.0), Node (Plus, Leaf (Value 3.0), Leaf (Value 5.0)))
printfn "Prefix traversal:\n%A" (prefix expr)
printfn "Infix traversal:\n%A" (infix expr)
printfn "Postfix traversal:\n%A" (postfix expr)
