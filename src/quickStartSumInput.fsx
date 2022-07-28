let sum x y = x + y
printfn "Adding a and b"
printf "Enter a: "
let a = float (System.Console.ReadLine ()) (*//§\label{quickStartSumInputA}§*)
printf "Enter b: "
let b = float (System.Console.ReadLine ()) (*//§\label{quickStartSumInputB}§*)
let c = sum a b
do printfn "%A" c
