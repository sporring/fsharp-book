module Library

let mutable i = 0
let greetings (str: string) : string =
  i <- i + 1
  sprintf "%A: Greetings %s" i str

let salutations (str: string) : string =
  "Hurray " + str
