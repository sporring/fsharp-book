let sum x y = x + y
printfn "Adding a and b"
printf "Enter a: "
let a = int (System.Console.ReadLine ()) (*//§\label{quickStartSumInputA}§*)
printf "Enter b: "
let b = int (System.Console.ReadLine ()) (*//§\label{quickStartSumInputB}§*)
let c = sum a b
do printfn "%A" c
