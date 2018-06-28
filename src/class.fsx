type aClass (anArgument : int) = (*//§\label{classHeader}§*)
  // Constructor body section §\label{classConstructorBodyStart}§
  let objectValue = anArgument 
  do printfn "A class has been created (%A)" objectValue (*//§\label{classConstructorBodyEnd}§*)
  // Member section §\label{classMemberStart}§
  member this.value = anArgument (*//§\label{classMemberValue}§*)
  member this.scale (factor : int) = factor * objectValue (*//§\label{classMemberFunction}\label{classMemberEnd}§*)

let a = aClass (2) (*//§\label{classObject}§*)
let b = aClass (1) (*//§\label{classObject2}§*)
printfn "%d %d %d" a.value (a.scale 3) b.value (*//§\label{classObjectUse}§*)
