(*
   Demonstration of recursion for keyboard input.
   Author: Jon Sporring
   Date: 2022/7/28
*)
   
// Description: Repeatedly ask the user for a non-zero number
//   until a non-zero value is entered.
// Arguments: None
// Result: the non-zero value entered
let rec readNonZeroValue () =
    // Note that the value of a is different for every
    // recursive call.
    let a = float (System.Console.ReadLine ())
    if a <> 0 then
      a
    else
      printfn "Error: zero value entered. Try again"
      readNonZeroValue ()
printfn "Please enter a non-zero value"
let b = readNonZeroValue ()
printfn "You typed: %A" b
