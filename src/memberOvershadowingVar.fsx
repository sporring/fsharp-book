/// hi is a greeting
type greeting () = 
  member this.str = "hi"
/// hello is a greeting
type hello () =
  inherit greeting ()
  member this.str = "hello"
/// howdy is a greeting
type howdy () =
  inherit greeting ()
  member this.str = base.str + " there"

let a = greeting ()
let b = hello ()
let c = howdy ()
printfn "%s, %s, %s" a.str b.str c.str
