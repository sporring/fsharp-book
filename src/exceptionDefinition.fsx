exception DontLikeFive of string

let picky a =
  if a = 5 then
    raise (DontLikeFive "5 sucks")
  else
    a
  
printfn "picky %A = %A" 3 (picky 3)
printfn "picky %A = %A" 5 (picky 5)
