type teacher () =
  member this.answer (q : string) = "4"
type student (t : teacher) =
  member this.ask () = t.answer("What is 2+2?")

let t = teacher ()
let s = student (t)
s.ask()
