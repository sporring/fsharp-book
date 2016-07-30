let rec printListRec (lst : int list) =
  match lst with
    elm::rest ->
      printf "%A " elm
      printListRec rest
    | _ ->
      printfn ""

let a = [1; 2; 3; 4; 5]
printListRec a
