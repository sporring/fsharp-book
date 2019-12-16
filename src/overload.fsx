type person (name : string) =
  member this.name = name
  member this.greetings () = name+" says hi"
  member this.greetings (str : string) =
    name+" "+str

let p = person ("Jon")
printfn "%s" (p.greetings ())
printfn "%s" (p.greetings "says goodbye")

