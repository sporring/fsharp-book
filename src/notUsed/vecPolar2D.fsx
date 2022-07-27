type vector(dir : float, len : float) =
  member this.dir = dir
  member this.len = len
  member this.multiply (a : float) : vector = 
    vector(this.dir, a * this.len)
  member this.add (a : vector) : vector = 
    let (x1,y1) = (this.len * cos this.dir, this.len * sin this.dir)
    let (x2,y2) = (a.len * cos a.dir, a.len * sin a.dir)
    let (x3,y3) = (x1 + x2, y1 + y2)
    vector(atan2 y3 x3, sqrt (x3 * x3 + y3 * y3))

let v = vector(3.1415 / 2.0, 2.0)
let w = vector(3.1415, 2.0)
let a = 1.5
let p = v.multiply a 
printfn "%A * (%A, %A) = (%A, %A)" a v.dir v.len p.dir p.len
let q = v.add(w)
printfn "(%A, %A) + (%A, %A) = (%A, %A)" v.dir v.len w.dir w.len q.dir q.len
