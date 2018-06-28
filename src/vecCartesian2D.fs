namespace Geometry
type vector(x : float, y : float) =
  new() =
    vector(0.0, 0.0)
  member this.x = x
  member this.y = y
  member this.len = sqrt (x * x + y * y)
  member this.dir = atan2 y x
  static member val left = "(" with get, set
  static member val right = ")" with get, set
  static member val sep = ", " with get, set
  static member ( * ) (a : float, v : vector) : vector =
    vector(a * v.x, a * v.y)
  static member ( * ) (v : vector, a : float) : vector =
    a * v
  static member (+) (v : vector, w : vector) : vector =
    vector(v.x + w.x, v.y + w.y)
  override this.ToString() = 
    sprintf "%s%A%s%A%s" vector.left this.x vector.sep this.y vector.right