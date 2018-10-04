let (|Gold|Silver|Bronze|) inp = (*//§\label{activeMultiCasePatternDef}§*)
  if inp = 0 then Gold 
  elif inp = 1 then Silver 
  else Bronze

let intToMedal (i : int) =
    match i with
      Gold -> printfn "%d: It's gold!" i (*//§\label{activeMultiCasePatternApp}§*)
      | Silver -> printfn "%d: It's silver." i
      | Bronze -> printfn "%d: It's no more than bronze." i

List.iter intToMedal [0..3]
