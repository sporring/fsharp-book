let apply f x y  = f x y
let mul = fun a b -> a * b
printfn "%d" (apply mul 3 6)
