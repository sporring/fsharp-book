type classDoThen (aValue : float) =
  // "do" is mandatory to execute code in the primary constructor §\label{classDoThenDoStart}§
  do printfn "  Primary constructor called"
  // Some calculations
  do printfn "  Primary done" (* §\label{classDoThenDoEnd}§*)
  new () = 
    // "do" is optional in additional constructors §\label{classDoThenDoAddStart}§
    printfn "  Additional constructor called" (*//§\label{classDoThenDoAddEnd}§*)
    classDoThen (0.0)
    // Use "then" to execute code after construction §\label{classDoThenThenStart}§
    then 
      printfn "  Additional done" (*// §\label{classDoThenThenEnd}§*)
  member this.value = aValue
 
printfn "Calling additional constructor"
let v = classDoThen ()
printfn "Calling primary constructor"
let w = classDoThen (1.0)
