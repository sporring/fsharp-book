type vector(x : float, y : float) =
  member this.x = x
  member this.y = y
  // Operators are functions and can be overloaded §\label{vecCartesian2DOperatorStart}§
  static member ( * ) (a : float, v : vector) : vector = 
    vector(a * v.x, a * v.y)
  static member ( * ) (v : vector, a : float) : vector =
    a * v
  static member (+) (v : vector, w : vector) : vector =
    vector(v.x + w.x, v.y + w.y) (*//§\label{vecCartesian2DOperatorEnd}§*)
 
let v = vector(1.0,2.0)
let w = vector(3.2,-1.8)
let a = 1.5
let p = a * v // Use normal syntax for overloaded operators §\label{vecCartesian2DOperatorAppMul}§
printfn "%A * (%A, %A) = (%A, %A)" a v.x v.y p.x p.y
let pSym = v * a (*//§\label{vecCartesian2DOperatorAppMulSym}§*)
printfn "(%A, %A) * %A = (%A, %A)" v.x v.y a pSym.x pSym.y
let q = v + w (*//§\label{vecCartesian2DOperatorAppAdd}§*)
printfn "(%A, %A) + (%A, %A) = (%A, %A)" v.x v.y w.x w.y q.x q.y
