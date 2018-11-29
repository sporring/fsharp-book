/// All vehicles have wheels
type vehicle (nWheels : int ) =
  member this.wheels = nWheels

/// A car is a vehicle with 4 wheels
type car (nPassengers : int) =
  inherit vehicle (4)
  member this.maxPassengers = nPassengers
  
/// A bicycle is a vehicle with 2 wheels
type bicycle () =
  inherit vehicle (2)
  member this.mustUseHelmet = true

let aVehicle = vehicle (1)
let aCar = car (4)
let aBike = bicycle ()
printfn "aVehicle has %d wheel(s)" aVehicle.wheels
printfn "aCar has %d wheel(s) with room for %d passenger(s)" aCar.wheels aCar.maxPassengers
printfn "aBike has %d wheel(s). Is helmet required? %b" aBike.wheels aBike.mustUseHelmet
