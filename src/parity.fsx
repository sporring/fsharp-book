let even x = (x % 2 = 0)
let odd x = not (even x)
let res = List.map (fun i -> (i, even i, odd i)) [1..3]
printfn "(i, even, odd):\n%A" res
