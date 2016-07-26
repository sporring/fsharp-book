let testScope x =
  let a = 3.0
  let f z = a * x
  let a = 4.0
  f x
printfn "%A" (testScope 2.0)
