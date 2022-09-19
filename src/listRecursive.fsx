let rec printList (lst : int list) : unit =
  match lst with
    [] ->
      printfn ""
    | elm::rest ->
      printf "%A " elm
      printList rest

printList [3; 4; 5]
