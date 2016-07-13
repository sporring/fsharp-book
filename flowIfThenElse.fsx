let abs x =
  if x < 0 then
    -x
  else
    x
printfn "%d" (abs 3)
printfn "%d" (abs -3)
