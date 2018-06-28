type classMutable (name : string) =
  member val greetings = "Hello" with get, set(*//§\label{classSetGetShortMemberValGetSet}§*)
  member this.name = name
  override this.ToString () =
    this.greetings + " " + name

let s = classMutable("F#")
let t = classMutable("F#")
t.greetings <- "Hi"
printfn "\"%A\", \"%A\", \"%A\"" s t (s.greetings)
