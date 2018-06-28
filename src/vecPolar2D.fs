namespace Geometry
type vector(dir : float, len : float) =
  do if len < 0.0 then failwith "Negative length in polar representation." 
  new() =
    vector(0.0, 0.0)
  member this.x = len * cos dir 
  member this.y = len * sin dir 
  member this.dir = dir
  member this.len = len
  static member val left = "(" with get, set
  static member val right = ")" with get, set
  static member val sep = ", " with get, set
  static member ( * ) (a : float, v : vector) : vector =
   vector(v.dir, a * v.len)
  static member ( * ) (v : vector, a : float) : vector =
    a * v
  static member (+) (v : vector, w : vector) : vector =
    let (x1,y1) = (v.len * cos v.dir, v.len * sin v.dir)
    let (x2,y2) = (w.len * cos w.dir, w.len * sin w.dir)
    let (x3,y3) = (x1 + x2, y1 + y2)
    vector(atan2 y3 x3, sqrt (x3 * x3 + y3 * y3))
  override this.ToString() = 
   sprintf "%s%A%s%A%s" vector.left this.x vector.sep this.y vector.right