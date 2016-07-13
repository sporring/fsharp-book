let defineMsg () = 
  let mutable msg = "hello"
  printfn "%s" msg
    
let setMsg () =
  msg <- "world"
    
setMsg ()
printfn "%s" msg
