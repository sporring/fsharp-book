[<Struct>]
type position = 
  val x : float
  val y : float
  new (a : float, b : float) = {x = a; y = b} 

let p = position (3.0, 4.2)
printfn "%A: x = %A, y = %A" p p.x p.y
