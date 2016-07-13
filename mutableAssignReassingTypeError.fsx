let mutable x = 5 // Declare a variable x and assign the value 5 to it
printfn "%d" x
x <- -3.0 // This is illegal, since -3.0 is a float, while x is of type int
printfn "%d" x
