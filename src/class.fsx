type car (econ : float, fuel : float) = (*//§\label{classHeader}§*)
  // Constructor body section §\label{classConstructorBodyStart}§
  let mutable fuelLeft = fuel // liters in the tank
  do printfn "Created a car (%.1f, %.1f)" econ fuel(*//§\label{classConstructorBodyEnd}§*)
  // Member section §\label{classMemberStart}§
  member this.fuel = fuelLeft 
  member this.drive distance =
    fuelLeft <- fuelLeft - econ * distance / 100.0(*//§\label{classMemberEnd}§*)

let sport = car (8.0, 60.0) (*//§\label{classObject}§*)
let economy = car (5.0, 45.0) (*//§\label{classObject2}§*)
sport.drive 100.0(*//§\label{classObjectUseStart}§*)
economy.drive 100.0
printfn "Fuel left after 100km driving:"
printfn " sport: %.1f" sport.fuel
printfn " economy: %.1f" economy.fuel(*//§\label{classObjectUseEnd}§*)
