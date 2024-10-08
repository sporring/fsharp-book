module bTree

type bTree<'a> = Node of 'a * bTree<'a> option * bTree<'a> option

let create (v: 'a) =  Node (v, None, None)

let replaceLeft (c: bTree<'a>) (Node (v, l, r)) : bTree<'a> =
  Node (v, Some c, r)

let replaceRight (c: bTree<'a>) (Node (v, l, r)) : bTree<'a> =
  Node (v, l, Some c)

let retrieveValue (Node (v, l, r)) : 'a = v

let tryRetrieveLeft (Node (v, l, r)) : bTree<'a> option = l

let tryRetrieveRight (Node (v, l, r)) : bTree<'a> option = r

let rec infix (Node (v, l, r)) : ('a list) =
  (l |> Option.map infix |> Option.defaultValue []) 
  @ [v]
  @ (r |> Option.map infix |> Option.defaultValue [])
