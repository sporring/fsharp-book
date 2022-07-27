let add : MetaExplicitModuleDefinition.floatFunction = fun x y -> x + y
let result = MetaExplicitModuleDefinition.apply add 3.0 4.0
printfn "3.0 + 4.0 = %A" result
