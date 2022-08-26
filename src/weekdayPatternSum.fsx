let whatToDoToday (d : int) : string =
  match d with
    0 | 1 | 2  | 3 | 4 -> "go to work"
    | 5 | 6  -> "take time off"
    | _ -> "unknown day of the week"

let dayOfWeek = 3
let task = whatToDoToday dayOfWeek
printfn "Day %A of the week you should %A" dayOfWeek task
