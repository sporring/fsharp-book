open Stack

type element = Value of float | Mul | Plus | Minus | Div
type bTree = Leaf of element | Node of element * bTree * bTree

/// Postfix traversal of a binary tree
let rec postfix (t: bTree) : (element list) =
  match t with
    Leaf e -> [e]
    | Node (e, left, right) ->
      (postfix left) @ (postfix right) @ [e]
/// Convert postfix traversal back into a tree
let rec fromPostfix (tkns: element list) (stck: stack<bTree>): stack<bTree> =
  match tkns with
    [] -> stck
    | elm::rst ->
      match elm with
        Value v -> 
          push (Leaf (Value v)) stck |> fromPostfix rst
        | _ ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (Node (elm, b, a)) stck2 |> fromPostfix rst

let src: bTree = Node (Div, Leaf (Value 1.0), Node (Plus, Leaf (Value 3.0), Leaf (Value 5.0)))
let psfx = postfix src
let tg = fromPostfix psfx (create ())
printfn "Original tree:\n%A" src
printfn "Postfix traversal:\n%A" psfx
printfn "From Postfix tranversal:\n%A" tg