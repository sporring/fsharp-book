let incr =       
  let counter = ref 0
  fun () ->  
    counter.Value <- counter.Value + 1
    counter
printfn "%d" (incr ()).Value
printfn "%d" (incr ()).Value
printfn "%d" (incr ()).Value
