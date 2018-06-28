type aClass () = 
  let mutable v = 0
  member this.value 
    with get () = v 
    and set (a) = v <- a

let a = aClass () 
printfn "%d" a.value
a.value<-2
printfn "%d" a.value
