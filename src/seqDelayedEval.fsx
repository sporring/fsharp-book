let s = seq { yield 1; yield 2; printfn "The sequence was evaluated to this point."; yield 3};;
printfn "%A" (Seq.item 0 s);;
printfn "That was 0"
printfn "%A" (Seq.item 1 s);;
printfn "That was 1"
printfn "%A" (Seq.item 2 s);;
printfn "That was 2"
