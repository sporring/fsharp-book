let updateFactor () =
  2

let multiplyWithFactor x =
  let a = ref 1
  a := updateFactor ()
  !a * x
  
printfn "%d" (multiplyWithFactor 3)
