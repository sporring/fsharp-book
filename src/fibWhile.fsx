let fib (n : int) : int =
  let mutable pair = (0, 1)
  let mutable i = 1
  while i < n do(*//§\label{fibWhileInvariant}§*)
    pair <- (snd pair, fst pair + snd pair)
    i <- i + 1
  snd pair(*//§\label{fibWhileInvariantContinue}§*)

printfn "fib(1) = %d" (fib 1)
printfn "fib(2) = %d" (fib 2)
printfn "fib(3) = %d" (fib 3)
printfn "fib(10) = %d" (fib 10)
