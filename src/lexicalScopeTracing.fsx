let testScope x = |\label{lexicalScopeTracing:testScope}|
  let a = 3.0 |\label{lexicalScopeTracing:a1}|
  let f z = a * z |\label{lexicalScopeTracing:f}|
  let a = 4.0 |\label{lexicalScopeTracing:a2}|
  f x |\label{lexicalScopeTracing:return}|
printfn "%A" (testScope 2.0) |\label{lexicalScopeTracing:print}|
