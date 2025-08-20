let g () =
  let mutable x = ref 0
  x
let a = g ()
let b = g ()
printfn "(%d, %d)" a.Value b.Value
a.Value <- 1
printfn "(%d, %d)" !a !b
