let dec2bin n =
  let rec dec2binHelper n =
    if n = 0 then ""
    else (dec2binHelper (n / 2)) + string (n % 2)

  if n < 0 then
    "Illegal value"
  else
    "0b" + 
    if n = 0 then
      "0"
    else
      dec2binHelper n

printfn "%4d -> %s" -1 (dec2bin -1)
printfn "%4d -> %s" 0 (dec2bin 0)
for i = 0 to 3 do
  printfn "%4d -> %s" (pown 10 i) (dec2bin (pown 10 i))
