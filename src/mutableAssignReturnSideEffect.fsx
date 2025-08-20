let updateFactor (factor: byref<int>) =
    factor <- 2

let multiplyWithFactor x =
    let mutable a = 1
    updateFactor &a
    a * x

printfn "%d" (multiplyWithFactor 3)