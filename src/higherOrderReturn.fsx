let incBy n = 
  fun x -> x + n
printfn "%A" (List.map (incBy 2) [2; 3; 5])
