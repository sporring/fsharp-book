let (name, age) = ("Jon", 50)
let getAgeString (age : int) : string =
  match age with
    0 -> "newborn"
    | 1 -> "1 year old" 
    | n -> (string n) + " years old"

printfn "%s is %s" name (getAgeString age)