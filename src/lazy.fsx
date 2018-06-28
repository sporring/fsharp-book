let a = 2;
let b = lazy (printfn "calulating"; a*a);
printfn "Before: %A" b
b.Force()
printfn "After: %A" b
b.Force()
printfn "After repeat: %A" b
