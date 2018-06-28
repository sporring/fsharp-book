type aClass () = 
  let mutable v = 0
  member this.value with get () = v and set (a) = v <- a

let a = aClass () 
let b = a (*//§\label{classReferenceAlias}§*)
a.value <- 2
printfn "%d %d" a.value b.value
