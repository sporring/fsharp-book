let arrayToString (x : int []) : string =
  match x with
    [|1;_;_|] -> "3 elements, first of is a one"
    | [|x;1;_|] -> "3 elements, first is " + (string x) + "Second is one"
    | x -> "A general array"

printfn "%s" (arrayToString [|1; 1; 1|])
printfn "%s" (arrayToString [|3; 1; 1|])
printfn "%s" (arrayToString [|1|])