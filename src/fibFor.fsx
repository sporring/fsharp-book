let fib n =
  let mutable prev = 1
  let mutable current = 1
  let mutable next = 0
  for i = 3 to n do
    next <- current + prev
    prev <- current
    current <- next
  next

printfn "fib(1) = 1"
printfn "fib(2) = 1"
for i = 3 to 10 do
  printfn "fib(%d) = %d" i (fib i)
