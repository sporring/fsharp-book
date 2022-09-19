let rec fib (n: uint) =
  match n with 
    0u -> 0u
    | 1u -> 1u
    | _ -> fib (n - 1u) + fib (n - 2u)

printfn "%A" (List.map fib [0u .. 10u])
