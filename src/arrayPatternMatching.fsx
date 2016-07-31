let name2String (arr : string array) =
  match arr with
    [| first; last|] -> last + ", " + first
    | _ -> ""
    
let listNames (arr :string array array) =
  let mutable str = ""
  for a in arr do
    str <- str + name2String a + "\n"
  str
    
let A = [|[|"Jon"; "Sporring"|]; [|"Alonzo"; "Church"|]; [|"John"; "McCarthy"|]|]
printf "%s" (listNames A)
