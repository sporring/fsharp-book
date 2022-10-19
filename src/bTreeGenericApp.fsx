open bTree

type element = Value of float | Mul | Plus | Minus | Div
let expr: bTree<element> = // 1/(3+5)
  create Div 
  |> replaceLeft (create (Value 1.0)) 
  |> replaceRight (
    create Plus 
    |> replaceLeft (create (Value 3.0)) 
    |> replaceRight (create (Value 5.0)))

printfn "Binary tree:\n%A" expr
printfn "Prefix traversal: %A" (prefix expr)
printfn "Infix traversal: %A" (infix expr)
printfn "Postfix traversal: %A" (postfix expr)
