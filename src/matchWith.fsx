let applesIHave n =
  match n with
    | 0 -> "I have no apples"
    | 1 -> "I have 1 apple"
    | _ -> "I have " + (string n) + " apples"

printfn "%A" (applesIHave 0)
printfn "%A" (applesIHave 1)
printfn "%A" (applesIHave 2)
printfn "%A" (applesIHave 10)
