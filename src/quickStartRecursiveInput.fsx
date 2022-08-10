let rec readNonZeroValue () = (*//§\label{quickStartRecursiveInputA}§*)
  let a = int (System.Console.ReadLine ())
  match a with
    0 -> (*//§\label{quickStartRecursiveInputB}§*)
      printfn "Error: zero value entered. Try again"
      readNonZeroValue ()
    | _ -> (*//§\label{quickStartRecursiveInputC}§*)
      a (*//§\label{quickStartRecursiveInputD}§*)
printfn "Please enter a non-zero value"
let b = readNonZeroValue ()
printfn "You typed: %A" b
