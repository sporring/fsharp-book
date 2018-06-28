type vector(x : float, y : float) =
  member this.x = x
  member this.y = y
  // Static members are the same for all objects §\label{vecCartesian2DStaticStart}§
  static member multiply (a : float) (v : vector) : vector = 
    vector(a * v.x, a * v.y)
  static member add (v : vector) (w : vector) : vector =
    vector(v.x + w.x, v.y + w.y)(*//§\label{vecCartesian2DStaticEnd}§*)
 
let v = vector(1.0,2.0)
let w = vector(3.2,-1.8)
let a = 1.5
let p = vector.multiply a v // Call static members with class name §\label{vecCartesian2DStaticUse1}§
printfn "%A * (%A, %A) = (%A, %A)" a v.x v.y p.x p.y
let q = vector.add v w (*//§\label{vecCartesian2DStaticUse2}§*)
printfn "(%A, %A) + (%A, %A) = (%A, %A)" v.x v.y w.x w.y q.x q.y
