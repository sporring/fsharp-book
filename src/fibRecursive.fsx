let rec fib (n: uint) =
  if n < 2u then n
  else fib (n - 1u) + fib (n - 2u)

printfn "%A" (List.map fib [0u .. 10u])
