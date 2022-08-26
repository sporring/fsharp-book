let whatToDoToday (d : int) : string =
  match d with
    n when 0 <= n && n < 5 -> "go to work"
    | n when 5 <= n && n <= 6  -> "take time off"

let dayOfWeek = 3
let task = whatToDoToday dayOfWeek
printfn "Day %A of the week you should %A" dayOfWeek task
