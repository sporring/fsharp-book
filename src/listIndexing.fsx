let printList (lst : int list) =
  for elm in lst do
    printf "%A " elm
  printfn ""

let printListAlt (lst : int list) =
  for i = 0 to lst.Length - 1 do
    printf "%A " lst.[i]
  printfn ""

let a = [1; 2;]
let b = [3; 4; 5]
let c = a @ b
let d = 0 :: c
printfn "%A, %A, %A, %A" a b c d
printList d
printListAlt d
