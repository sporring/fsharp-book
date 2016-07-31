let rec square a =
  match a with
    elm :: rest -> elm*elm :: (square rest)
    | _ -> []

let a = [1 .. 10]
printfn "%A" (square a)    
