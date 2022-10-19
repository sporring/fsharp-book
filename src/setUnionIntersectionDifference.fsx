let s1 = Set [3..5]
let s2 = Set [4;6;1]
printfn "s1 = %A\ns2 = %A" s1 s2
printfn "s1 union s2 = %A" (Set.union s1 s2)
printfn "s1 intersect s2 = %A" (Set.intersect s1 s2)
printfn "s1 difference s2 = %A" (Set.difference s1 s2)
