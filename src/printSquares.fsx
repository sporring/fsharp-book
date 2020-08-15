let N = 3 (*//§\label{printSquares:N}§*)
let printSquares n = (*//§\label{printSquares:squares}§*)
  for i = 1 to n do (*//§\label{printSquares:for}§*)
    let p = i * i (*//§\label{printSquares:p}§*)
    printfn "%d: %d" i p (*//§\label{printSquares:printfn}§*)

printSquares N (*//§\label{printSquares:call}§*)
