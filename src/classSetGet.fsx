type classMutable (name : string) =
  let mutable secretGreetings = "Hello"
  // Define getters and setters wrapping a mutable variable §\label{classSetGetStart}§
  member this.greetings
    with get () = secretGreetings 
    and set (greetings : string) = secretGreetings <- greetings(*//§\label{classSetGetEnd}§*)
  member this.name = name
  override this.ToString () =
    secretGreetings + " " + name

let s = classMutable("F#")
let t = classMutable("F#")
// Call set as mutable variable §\label{classSetGetAppStart}§
t.greetings <- "Hi" 
printfn "\"%A\", \"%A\", \"%A\"" s t (s.greetings) (*//§\label{classSetGetAppEnd}§*)
