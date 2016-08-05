exception DontLikeFive of string

let div enum denom =
  if denom = 5 then
    raise (DontLikeFive "5 sucks")
  try
    Some (enum / denom)
  with
    | :? System.DivideByZeroException -> None

printfn "3 / 1 = %A" (div 3 1)
printfn "3 / 0 = %A" (div 3 0)
printfn "3 / 5 = %A" (div 3 5)
