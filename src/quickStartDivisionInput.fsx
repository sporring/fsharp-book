let div x y = x / y
printfn "Dividing a by b"
printf "Enter a: "
let a = int (System.Console.ReadLine ())
printf "Enter b: "
let b = int (System.Console.ReadLine ())
match b with (*//§\label{quickStartDivisionInputA}§*)
  0 ->
    do printfn "Input error: Cannot divide by zero" (*//§\label{quickStartDivisionInputB}§*)
  | _ ->
    let c = div a b (*//§\label{quickStartDivisionInputC}§*)
    do printfn "%A" c (*//§\label{quickStartDivisionInputD}§*)
