type vector = 
  Vec2D of float * float
  | Vec3D of x : float * y : float * z : float

let v2 = Vec2D (1.0, -1.2)
let v3 = Vec3D (x = 1.0, z = -1.2, y = 0.9)
printfn "%A and %A" v2 v3
