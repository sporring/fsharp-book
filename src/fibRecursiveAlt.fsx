let fib (n: uint) =
  let rec fibPair n pair =
    if n < 2u then pair
    else fibPair (n - 1u) (snd pair, fst pair + snd pair)

  fibPair n (0u, 1u) |> snd

printfn "fib(10) = %A" (fib 10u)
