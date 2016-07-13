let updateFactor factor =
  factor := 2

let multiplyWithFactor x =
  let a = ref 1
  updateFactor a
  !a * x
  
printfn "%d" (multiplyWithFactor 3)
