let div enum denom =
  try
    enum / denom
  with
    | :? System.DivideByZeroException -> System.Int32.MaxValue
printfn "3 / 1 = %d" (div 3 1)
printfn "3 / 0 = %d" (div 3 0)
