open Geometry
vector.left <- "["
vector.right <- "]"
let v = vector(1.0,2.0)
let w = vector(3.2,-1.8)
let a = 1.5
let p = a * v
printfn "%A * %A = %A" a v p
let pSym = v * a
printfn "%A * %A = %A" v a pSym
let q = v + w
printfn "%A + %A = %A" v w q
printfn "v.dir = %A" v.dir
printfn "v.len = %A" v.len