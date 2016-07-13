let apply (f, x, y)  = f (x, y)
let z = apply ((fun (a, b) -> a * b), 3, 6)
printfn "%d" z
