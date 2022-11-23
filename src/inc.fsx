let inc () =
  let mutable s = 0
  s <- s + 1
  s

printfn "%A" (inc ())
printfn "%A" (inc ())
printfn "%A" (inc ())
