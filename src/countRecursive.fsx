let rec count a b =
  match a with
    i when i > b ->
      printfn ""
    | _ -> 
      printf "%d " a
      count (a + 1) b

count 1 10 (*//§\label{countRecursiveCall}§*)
