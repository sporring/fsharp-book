let g () =
  let x = ref 0
  x
let  a = g ()
let b = g ()
printfn "(%d, %d)" !a !b
a := 1
printfn "(%d, %d)" !a !b
