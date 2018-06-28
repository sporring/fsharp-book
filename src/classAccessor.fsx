type aClass () = 
  let mutable v = 1
  member this.setValue (newValue : int) : unit = 
    v <- newValue
  member this.getValue () : int = v

let a = aClass ()
printfn "%d" (a.getValue ())
a.setValue (2)
printfn "%d" (a.getValue ())
