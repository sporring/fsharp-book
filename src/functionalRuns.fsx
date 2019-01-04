let indToRel = [
  fun elm -> (elm,0); // South by elm
  fun elm -> (-elm,0); // North by elm
  fun elm -> (0,elm); // West by elm
  fun elm -> (0,-elm) // East by elm
  ]
let rec makeRuns lst =
  match lst with
    | [] -> []
    | f :: rest ->
      let run = List.map f [1..7]
      run :: makeRuns rest
makeRuns indToRel
    
