let div x y = x / y
printfn "Dividing a by b"
printf "Enter a: "
let a = float (System.Console.ReadLine ())
printf "Enter b: "
let b = float (System.Console.ReadLine ())
if b = 0 then (*//§\label{quickStartDivisionInputA}§*)
    do printfn "Input error: Cannot divide by zero"
else
    let c = div a b
    do printfn "%A" c (*//§\label{quickStartDivisionInputB}§*)
