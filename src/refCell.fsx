let x = ref 0
printfn "%d" x.Value
x.Value <- x.Value + 1
printfn "%d" x.Value
