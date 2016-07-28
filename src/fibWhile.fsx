let largestFibLeq n =
  let mutable a = 1
  let mutable b = 1
  let mutable f = 0
  while f <= n do
    f <- a + b
    a <- b
    b <- f
  a

printfn "largestFibLeq(1) = 1"
printfn "largestFibLeq(2) = 1"
for i = 3 to 10 do
  printfn "largestFibLeq(%d) = %d" i (largestFibLeq i)
