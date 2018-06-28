let inc n = 
  fun x -> x + n
printfn "%A" (List.map (inc 1) [2; 3; 5])
