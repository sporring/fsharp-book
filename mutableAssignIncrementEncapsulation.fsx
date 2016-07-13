let incr =       
  let mutable counter = 0
  fun () ->  
    counter <- counter + 1
    counter
printfn "%d" (incr ())
printfn "%d" (incr ())
printfn "%d" (incr ())
