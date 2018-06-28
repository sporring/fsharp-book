let inline plus (x : ^a) (y : ^a) : ^a when ^a : (static member ( + ) :  ^a * ^a -> ^a) = x + y

printfn "%A %A" (plus 1 2) (plus 1.0 2.0)