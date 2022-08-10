let readNonZeroValueAlt () = 
  let mutable a = int (System.Console.ReadLine ()) (*//§\label{quickStartWhileInputA}§*)
  while a = 0 do (*//§\label{quickStartWhileInputB}§*)
    printfn "Error: zero value entered. Try again"(*//§\label{quickStartWhileInputC}§*)
    a <- int (System.Console.ReadLine ()) (*//§\label{quickStartWhileInputD}§*)
  a (*//§\label{quickStartWhileInputE}§*)
printfn "Please enter a non-zero value"
let b = readNonZeroValueAlt ()
printfn "You typed: %A" b
