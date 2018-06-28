let mul x y = x * y
let factor = 2.0
let applyFactor fct x = 
  let a = fct factor x
  string a

do printfn "%g" (mul 5.0 3.0)
do printfn "%s" (applyFactor mul 3.0) (*//§\label{functionFirstClassApplyFactor}§*)