/// A general vehicle, which moves on a plane and has a heading
type vehicle () =
  let mutable p = (0.0, 0.0) // coordinate on a plane
  let mutable d = 0.0 // heading direction in radians
  member this.dir with get() = d
  member this.pos with get() = p and set aPos = p <- aPos
  member this.turn angle = // turn heading
    d <- d + angle
  member this.forward step = // move forward (abs step)
    let s = abs step
    let vec = (s * (cos d), s * (sin d))
    p <- (fst p + fst vec, snd p + snd vec)
/// A car is a vehicle, has wheels and can move in reverse
type car (name) =
  inherit vehicle () // inherit dir, pos, turn, and forward
  member this.wheels = 4 // A car has 4 wheels
  member this.revese step = // move backwards (abs step)
    let s = - abs step
    let vec = (s * (cos this.dir), s * (sin this.dir))
    this.pos <- (fst this.pos + fst vec, snd this.pos + snd vec)
/// A bicycle is a vehicle and has wheels
type bicycle () =
  inherit vehicle () // inherit dir, pos, turn, and forward
  member this.wheels = 2 // A bike has 4 wheels

let aVehicle = vehicle () // has dir, pos, turn, forward
let aCar = car () // has dir, pos, turn, forward, wheels, reverse
let aBike = bicycle () // has dir, pos, turn, forward, wheels
printfn "The car aCar has %d wheels" aCar.wheels
printfn "The bicycle aBike has %d wheels" aBike.wheels
