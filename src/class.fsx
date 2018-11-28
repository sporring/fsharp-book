type car (col : string, econ : float, fuel : float) = (*//§\label{classHeader}§*)
  // Constructor body section §\label{classConstructorBodyStart}§
  let fuelEconomy = econ // liters spent per 100 km 
  do printfn "A %s car has been created" col(*//§\label{classConstructorBodyEnd}§*)
  // Member section §\label{classMemberStart}§
  member this.color = col (*//§\label{classMemberValue}§*)
  member this.fuel = fuel // liters in the tank
  member this.estimateUsage distance = econ * distance / 100.0(*//§\label{classMemberEnd}§*)

let estimate (aCar : car) (km : float) : float =
  aCar.fuel - aCar.estimateUsage km(*//§\label{functionOnObjects}§*)
let sport = car ("red", 8.0, 60.0) (*//§\label{classObject}§*)
let economy = car ("blue", 5.0, 45.0) (*//§\label{classObject2}§*)
printfn "Fuel left after 100km driving:"
printfn "%s: %.1f" sport.color (estimate sport 100.0)(*//§\label{classObjectUseStart}§*)
printfn "%s: %.1f" economy.color (estimate economy 100.0)(*//§\label{classObjectUseEnd}§*)
