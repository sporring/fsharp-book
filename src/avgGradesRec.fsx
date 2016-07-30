let averageGrade courseGrades =
  let rec sumNCount lst =
    match lst with
      | (title, grade)::rest ->
        let (sum, n) = sumNCount rest
        (sum + grade, n + 1)
      | _ -> (0, 0)

  let (sum, n) = sumNCount courseGrades
  (float sum) / (float n)

let courseGrades =
    ["Introduction to programming", 95;
    "Linear algebra", 80;
    "User Interaction", 85;]

printfn "Course and grades:\n%A" courseGrades
printfn "Average grade: %.1f" (averageGrade courseGrades)
