let f x = printfn "%A" x
let g x y = printfn "%A %A" x y
let h x y z = printfn "%A %A %A" x y z

1 |> f
(1, 2) ||> g
(1, 2, 3) |||> h