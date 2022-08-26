let a = [|1; 2; 3|];
let b = a
a[0] <- 0
printfn "a = %A, b = %A" a b;;
