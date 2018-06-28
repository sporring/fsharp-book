let divideBy denom enum =
  if denom = 0.0 then
    None
  else
    Some (enum/denom)

let success =
  Some 1.0
  |> Option.bind (divideBy 2.0)
  |> Option.bind (divideBy 3.0)
printfn "%A" success

let fail =
  Some 1.0
  |> Option.bind (divideBy 0.0)
  |> Option.bind (divideBy 3.0)
printfn "%A; isNone: %b" fail fail.IsNone
