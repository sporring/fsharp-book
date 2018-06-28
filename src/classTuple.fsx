type vectorWTupleArgs (x : float * float) =
  member this.cartesian = x
type vectorWTwoArgs (x : float, y : float) =
  member this.cartesian = (x,y)
let v = vectorWTupleArgs (1.0, 2.0)
let w = vectorWTwoArgs (1.0, 2.0)
