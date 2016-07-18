let digitToString x =
  if x < 1 then
    '0'
  else
    if x < 2 then
      '1'
    else
      '2'

printfn "%c" (digitToString 1)
printfn "%c" (digitToString 3)
printfn "%c" (digitToString -3)
