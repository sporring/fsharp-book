module bTree

type bTree<'a> = Node of 'a * bTree<'a> option * bTree<'a> option

let create (v: 'a) = 
  Node (v, None, None)

let replaceValue (v: 'a) (Node (_, l, r)) : bTree<'a> = 
  Node (v, l, r)

let replaceLeft (c: bTree<'a>) (Node (v, l, r)) : bTree<'a> =
  Node (v, Some c, r)

let replaceRight (c: bTree<'a>) (Node (v, l, r)) : bTree<'a> =
  Node (v, l, Some c)

let retrieveValue (Node (v, l, r)) : 'a = v

let tryRetrieveLeft (Node (v, l, r)) : bTree<'a> option = l

let tryRetrieveRight (Node (v, l, r)) : bTree<'a> option = r

let rec prefix (Node (v, l, r)) : ('a list) =
  v
  :: (l |> Option.map prefix |> Option.defaultValue []) 
  @ (r |> Option.map prefix |> Option.defaultValue [])

let rec infix (Node (v, l, r)) : ('a list) =
  (l |> Option.map infix |> Option.defaultValue []) 
  @ [v]
  @ (r |> Option.map infix |> Option.defaultValue [])

let rec postfix (Node (v, l, r)) : ('a list) =
  (l |> Option.map postfix |> Option.defaultValue []) 
  @ (r |> Option.map postfix |> Option.defaultValue [])
  @ [v]
