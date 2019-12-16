type book (name : string) =
  let mutable _name = name
type author () =
  let _book = book("Learning to program")
  member this.publish() = _book
type reader () =
  let mutable _book : book option = None
  member this.buy (b : book) = _book <- Some b

let a = author ()
let r = reader ()
let b = a.publish ()
r.buy (b)
