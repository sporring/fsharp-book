let indToRel = [
  fun elm -> (elm,0); // South by elm
  fun elm -> (-elm,0); // North by elm
  fun elm -> (0,elm); // West by elm
  fun elm -> (0,-elm) // East by elm
  ]
let mutable listOfRuns : ((int * int) list) list = []
for f in indToRel do
  let run = List.map f [1..7]
  listOfRuns <- run :: listOfRuns
