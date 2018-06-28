type classMutable (name : string) =
  let mutable greetings = "Hello"(*//§\label{classMutableVar}§*)
  member this.name = name
  member this.setGreetings (aGreeting: string) =
    greetings <- aGreeting
  member this.getGreetings () =
    greetings
  override this.ToString () =
    greetings + " " + name

let s = classMutable ("F#")
let t = classMutable ("F#")
t.setGreetings ("Hi")
printfn "\"%A\", \"%A\", \"%A\"" s t (s.getGreetings ())(*//§\label{classMutableApp}§*)
