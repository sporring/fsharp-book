type Medal = Gold | Silver | Bronze
let statement (m : Medal) : string =
  if m = Gold then "You won"
  elif m = Silver then "You almost won"
  else "Maybe you can win next time"

let m = Silver
printfn "%A : %s" m (statement m)
