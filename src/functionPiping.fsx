let f x = x + 1
let g x = x * x

let a = g (f 2)(*//§\label{functionPipingComposition}§*)
let b = 2 |> f |> g(*//§\label{functionPipingLeftToRight}§*)
let c = g <| (f <| 2)(*//§\label{functionPipingRightToLeft}§*)
do printfn "a = %A, b = %A, c = %A" a b c