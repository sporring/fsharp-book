type car (aColor : string) = (*//§\label{carHeader}§*)
  // Member section §\label{carMemberStart}§
  member this.color = aColor (*//§\label{carMemberValue}§*) (*//§\label{carMemberEnd}§*)

let sportsCar = car ("red") (*//§\label{carObject1}§*)
let stationWagon = car ("green") (*//§\label{carObject2}§*)
let miniBus = car ("blue") (*//§\label{clarObject3}§*)
printfn "%s %s %s" sportsCar.color stationWagon.color miniBus.color (*//§\label{carObjectUse}§*)
