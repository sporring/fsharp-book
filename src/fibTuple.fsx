let fib n =
  let mutable prev = (0, 1)
  for i = 2 to n do
    prev <- (snd prev, (fst prev) + (snd prev))
  snd prev

printfn "fib(1) = %d" (fib 1)
printfn "fib(2) = %d" (fib 2)
printfn "fib(3) = %d" (fib 3)
printfn "fib(10) = %d" (fib 10)