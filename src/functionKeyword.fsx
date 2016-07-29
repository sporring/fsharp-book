let applesIHave = function
  i when i < 0 -> "I owe " + (string -i) + " apples"
  | 0 -> "I have no apples"
  | 1 -> "I have 1 apple"
  | n -> "I have " + (string n) + " apples"
  
printfn "%A" (applesIHave -3)
printfn "%A" (applesIHave -1)
printfn "%A" (applesIHave 0)
printfn "%A" (applesIHave 1)
printfn "%A" (applesIHave 2)
printfn "%A" (applesIHave 10)
