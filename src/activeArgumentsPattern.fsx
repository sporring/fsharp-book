type vec = {x : float; y : float}
let (|Polar|) (o : vec) (v : vec) = 
  let x = v.x - o.x
  let y = v.y - o.y
  (sqrt(x*x + y * y), atan2 y x)
let printPolar (o : vec) (p : vec) : unit =
    match p with
      Polar o (a, d) -> printfn "%A:\n Cartesian (%A, %A)" p a d (*//§\label{activeArgumentsPatternApp}§*)

let v = {x = 2.0; y = 3.0}
let offset = {x = 1.0; y = 1.0}
printPolar offset v