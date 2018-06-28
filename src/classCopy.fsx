type aClass () = 
  let mutable v = 0
  member this.value with get () = v and set (a) = v <- a
  member this.copy () =
    let o = aClass ()
    o.value <- v
    o
let a = aClass () 
let b = a.copy ()
a.value<-2
printfn "%d %d" a.value b.value
