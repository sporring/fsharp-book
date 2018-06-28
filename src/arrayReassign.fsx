let square (a : int array) =
  for i = 0 to a.Length - 1 do
    a.[i] <- a.[i] * a.[i]
    
let A = [| 1; 2; 3; 4; 5 |]
printfn "%A" A
square A
printfn "%A" A