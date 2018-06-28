exception DontLikeFive of string

let picky a =
  if a = 5 then
    raise (DontLikeFive "5 sucks")
  else
    a
  
printfn "picky %A = %A" 3 (try picky 3 |> string with ex -> ex.Message)
printfn "picky %A = %A" 5 (try picky 5 |> string with ex -> ex.Message)
