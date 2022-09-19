type Lst = Ground | Element of int*Lst
let rec traverse (l : Lst) : string =
    match l with
      Ground -> ""
      | Element(i,Ground) -> string i
      | Element(i,rst) -> string i + ", " + (traverse rst)

let lst = Element (1, Element (2, Element (3, Ground)))
printfn "%A" (traverse lst)
