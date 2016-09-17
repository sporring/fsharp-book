let applesIHave n =
  if n < -1 then "I owe " + (string -n) + " apples"
  elif n < 0 then "I owe " + (string -n) + " apple"
  elif n < 1 then "I have no apples"
  elif n < 2 then "I have 1 apple"
  else "I have " + (string n) + " apples"

printfn "%A" (applesIHave -3)
printfn "%A" (applesIHave -1)
printfn "%A" (applesIHave 0)
printfn "%A" (applesIHave 1)
printfn "%A" (applesIHave 2)
printfn "%A" (applesIHave 10)
