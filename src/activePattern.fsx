type vec = {x : float; y : float}
let (|Cartesian|) (v : vec) = (v.x, v.y) (*//§\label{activePatternCartesian}§*)
let (|Polar|) (v : vec) = (sqrt(v.x*v.x + v.y * v.y), atan2 v.y v.x)(*//§\label{activePatternPolar}§*)
let printCartesian (p : vec) : unit =
    match p with
      Cartesian (x, y) -> printfn "%A:\n Cartesian (%A, %A)" p x y(*//§\label{activePatternCartesianApp}§*)
let printPolar (p : vec) : unit =
    match p with
      Polar (a, d) -> printfn "%A:\n Polar (%A, %A)" p a d(*//§\label{activePatternPolarApp}§*)

let v = {x = 2.0; y = 3.0}
printCartesian v
printPolar v
