type Base () =
  let aValue = 3
  let mutable _str = "Hi"
  member this.str
    with get () = _str
    and set (v) = _str <- v
type Deriv1 (name) =
  inherit Base ()
  member this.greetings = this.str + " " + name
type Deriv2 () =
  inherit Base ()
  member this.count = 
    sprintf "%A has %d characters" this.str this.str.Length
let a = Base ()
let b = Deriv1 ("F# programmer")
let c = Deriv2 ()
printfn "%A" a.str
printfn "%A, %A" b.str b.greetings
printfn "%A, %A" c.str c.count
