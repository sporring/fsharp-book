type Greetings () = 
  let mutable greetings = "Hi"
  let mutable name = "Programmer"
  member this.str = greetings + " " + name
  member this.setName (newName : string) : unit = 
    name <- newName
  member this.setName (newName : string, newGreetings : string) : unit =
    greetings <- newGreetings
    name <- newName
let a = Greetings () 
printfn "%s" a.str
a.setName ("F# programmer")
printfn "%s" a.str
a.setName ("Expert", "Hello")
printfn "%s" a.str
