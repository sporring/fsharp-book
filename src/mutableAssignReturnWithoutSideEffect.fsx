let updateFactor () =
  2

let multiplyWithFactor x =
  let a = ref 1
  a.Value <- updateFactor ()
  a.Value * x
  
printfn "%d" (multiplyWithFactor 3)
