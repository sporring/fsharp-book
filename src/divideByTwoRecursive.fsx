let rec divideByTwo (n: uint) : string =
  match n with
    0u -> ""
    | _ -> (divideByTwo (n/2u)) + (string (n%2u))

printfn "13u_10 = %A_2" (divideByTwo 13u)
