let divideBy denom enum =
  if denom = 0.0 then
    None
  else
    Some (enum/denom)
let divideByOption x acc =
  Option.bind (divideBy x) acc

let success = List.foldBack divideByOption [3.0; 2.0; 1.0] (Some 1.0)
printfn "%A" success

let fail = List.foldBack divideByOption [3.0; 0.0; 1.0] (Some 1.0)
printfn "%A; isNone: %A" fail fail.IsNone
