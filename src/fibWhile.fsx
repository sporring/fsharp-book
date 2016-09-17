let largestFibLeq n =
  let mutable prev = 1
  let mutable current = 1
  let mutable next = 0
  while next <= n do
    next <- prev + current
    prev <- current
    current <- next
  prev

printfn "largestFibLeq(1) = 1"
printfn "largestFibLeq(2) = 1"
for i = 3 to 10 do
  printfn "largestFibLeq(%d) = %d" i (largestFibLeq i)
