let s1 = Set [3..5]
let s2 = Set.empty |> Set.add 3 |> Set.add 4 |> Set.add 5
printfn "s1 = %A\ns2 = %A" s1 s2
