type vector(x : float, y : float) =
  member this.x = x
  member this.y = y
  static member multiply (a : float, v : vector) : vector =
    vector(a * v.x, a * v.y)
  static member multiply (v : vector, a : float) : vector =
    vector.multiply (a, v)
  static member add (v : vector) (w : vector) : vector =
    vector(v.x + w.x, v.y + w.y)
 
let v = vector(1.0,2.0)
let w = vector(3.2,-1.8)
let a = 1.5
let p = vector.multiply (a, v)
printfn "%A * (%A, %A) = (%A, %A)" a v.x v.y p.x p.y
let pSym = vector.multiply (v, a)
printfn "(%A, %A) * %A = (%A, %A)" v.x v.y a pSym.x pSym.y
let q = vector.add v w
printfn "(%A, %A) + (%A, %A) = (%A, %A)" v.x v.y w.x w.y q.x q.y
