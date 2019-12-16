type button =
  abstract member press : unit -> string
type television () =
  interface button with 
    member this.press () = "Changing channel"
type car () =
  interface button with 
    member this.press () = "Activating wipers"
let pressIt (elm : #button) =
  elm.press()

let t = television()
let c = car()
printfn "%s" (pressIt t)
printfn "%s" (pressIt c)
