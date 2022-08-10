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
  let a = int (System.Console.ReadLine ())
  match a with
    0 -> 
      printfn "Error: zero value entered. Try again"
      readNonZeroValue ()
    | _ ->
      a
printfn "Please enter a non-zero value"
let b = readNonZeroValue ()
printfn "You typed: %A" b
