let whatToDoToday (d : int) : string =
    if 0 <= d && d < 5 then "go to work"
    elif 5 <= d && d <= 6  then "take time off"
    else "unknown day of the week"

let dayOfWeek = 3
let task = whatToDoToday dayOfWeek
printfn "Day %A of the week you should %A" dayOfWeek task
