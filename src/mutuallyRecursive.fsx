let rec even x =
  if x = 0 then true
  else odd (x - 1)
and odd x =
  if x = 0 then false
  else even (x - 1)

let res = List.map (fun i -> (i, even i, odd i)) [1..3]
printfn "(i, even, odd):\n%A" res
