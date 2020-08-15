let rec gcd a b = (*//§\label{gcd:gcd}§*)
  if a < b then (*//§\label{gcd:if}§*)
    gcd b a (*//§\label{gcd:gcdR1}§*)
  elif b > 0 then (*//§\label{gcd:elif}§*)
    gcd b (a % b)  (*//§\label{gcd:gcdR2}§*)
  else 
    a (*//§\label{gcd:return}§*)

let a = 10 (*//§\label{gcd:a}§*)
let b = 15 (*//§\label{gcd:b}§*)
printfn "gcd %d %d = %d" a b (gcd a b) (*//§\label{gcd:printfn}§*)
