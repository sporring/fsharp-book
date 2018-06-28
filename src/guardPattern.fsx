let getAgeString (age : int) : string =
  match age with
    n when n < 1 -> "infant"
    | n when n < 13 -> "child" 
    | n when n < 20 -> "teen" 
    | _ -> "adult"

printfn "A person aged %d is a/an %s" 50 (getAgeString 50)