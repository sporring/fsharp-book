let rec readNonZeroValue () = (*//§\label{quickStartRecursiveInputA}§*)
    let a = float (System.Console.ReadLine ())
    if a <> 0 then (*//§\label{quickStartRecursiveInputB}§*)
      a
    else (*//§\label{quickStartRecursiveInputC}§*)
      printfn "Error: zero value entered. Try again"
      readNonZeroValue ()
printfn "Please enter a non-zero value"
let b = readNonZeroValue ()
printfn "You typed: %A" b
