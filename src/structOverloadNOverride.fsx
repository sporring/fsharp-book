[<Struct>]
type position = 
  val x : float
  val y : float
  new (a : float, b : float) = {x = a; y = b} 
  new (a : int, b : int) = {x = float a; y = float b}
  override this.ToString() =
    "(" + (string this.x) + ", " + (string this.y) + ")"

let pFloat = position (3.0, 4.2)
let pInt = position (3, 4)
printfn "%A and %A" pFloat pInt
