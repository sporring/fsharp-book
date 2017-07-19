
let add : Utilities.Meta.floatFunction = fun x y -> x + y
let result = Utilities.Meta.apply Utilities.MathFcts.add 3.0 4.0
printfn "3.0 + 4.0 = %A" result
