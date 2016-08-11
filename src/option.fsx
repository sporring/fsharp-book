let a = Some 3;
let b = None;
printfn "%A %A" a b
printfn "%A %b %b" a.Value b.IsSome b.IsNone
