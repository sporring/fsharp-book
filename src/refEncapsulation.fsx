let incr =       
  let counter = ref 0
  fun () ->  
    counter := !counter + 1
    !counter
printfn "%d" (incr ())
printfn "%d" (incr ())
printfn "%d" (incr ())
