/// An abstract class for general greeting classes with property str
[<AbstractClass>]
type greeting () = 
  abstract member str : string
  default this.str = "hello" // Provide default implementation §\label{abstractDefaultClassStart}§§\label{abstractDefaultClassEnd}§
/// hello is a greeting
type hello () =
  inherit greeting ()
/// howdy is a greeting
type howdy () =
  inherit greeting ()
  override this.str = "howdy"

let a = hello ()
let b = howdy ()
let c = [| a :> greeting; b :> greeting |] // arrays of greetings
Array.iter (fun (elm : greeting) -> printfn "%s" elm.str) c
