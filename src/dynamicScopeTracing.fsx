let testScope x = |\label{dynamicScopeTracing:testScope}|
  let mutable a = 3.0 |\label{dynamicScopeTracing:a1}|
  let f z = a * z |\label{dynamicScopeTracing:f}|
  a <- 4.0 |\label{dynamicScopeTracing:a2}|
  f x |\label{dynamicScopeTracing:return}|
printfn "%A" (testScope 2.0) |\label{dynamicScopeTracing:print}|
