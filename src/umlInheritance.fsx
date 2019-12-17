type person (name : string) =
  member this.name = name
type student (name : string, book : string) =
  inherit person(name)
  member this.book = book
type teacher (name : string, slides : string) = 
  inherit person(name)
  member this.slides = slides

let s = student("Hans", "Learning to Program")
let t = teacher("Jon", "Slides of the day")
