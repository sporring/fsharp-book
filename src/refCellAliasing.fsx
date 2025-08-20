let a = ref 1
let b = a
printfn "%d, %d" a.Value b.Value
b.Value <- 2
printfn "%d, %d" a.Value b.Value
