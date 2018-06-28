[<Literal>]
let TheAnswer = 42
let whatIsTheQuestion (x : int) : string =
  match x with
    TheAnswer -> "We will need to build a bigger machine..."
    | _ -> "Don't know that either"

printfn "%A" (whatIsTheQuestion 42)