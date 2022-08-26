let printList (lst : int list) : unit =
  for i = 0 to lst.Length - 1 do
    printf "%A " lst[i]
  printfn ""

let lst = [3; 4; 5]
printfn "lst = %A, lst[1] = %A" lst lst[1]
printfn "lst.Length = %A, lst.isEmpty = %A" lst.Length lst.IsEmpty
printList lst
