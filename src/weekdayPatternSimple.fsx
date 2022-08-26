let whatToDoToday (d : int) : string =
  match d with
    0 -> "go to work"
    | 1 -> "go to work"
    | 2  -> "go to work"
    | 3 -> "go to work"
    | 4 -> "go to work"
    | 5 -> "take time off"
    | 6  -> "take time off"
    | _ -> "unknown day of the week"

let dayOfWeek = 3
let task = whatToDoToday dayOfWeek
printfn "Day %A of the week you should %A" dayOfWeek task
