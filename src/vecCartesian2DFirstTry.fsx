type vector(x : float, y : float) =
  member this.x = x (*//§\label{vecCartesian2DFirstTryBodyStart}§*)
  member this.y = y
  member this.multiply (a : float) : vector = 
    vector(a * this.x, a * this.y)
  member this.add (a : vector) : vector = 
    vector(this.x + a.x, this.y + a.y)(*//§\label{vecCartesian2DFirstTryBodyEnd}§*)

let v = vector(1.0,2.0)(*//§\label{vecCartesian2DFirstTryCreateV}§*)
let w = vector(3.2,-1.8)(*//§\label{vecCartesian2DFirstTryCreateW}§*)
let a = 1.5
let p = v.multiply a (*//§\label{vecCartesian2DFirstTryCallMultiply}§*)
printfn "%A * (%A, %A) = (%A, %A)" a v.x v.y p.x p.y
let q = v.add w
printfn "(%A, %A) + (%A, %A) = (%A, %A)" v.x v.y w.x w.y q.x q.y
