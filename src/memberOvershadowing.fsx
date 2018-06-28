/// A counter has an internal state initialized at instantiation and
/// is incremented in steps of 1
type counter (init : int) =
  let mutable i = init
  member this.value with get () = i and set (v) = i <- v
  member this.inc () = i <- i + 1
/// A counter2 is a counter which increments in steps of 2. 
type counter2 (init : int) =
  inherit counter (init)
  member this.inc () = this.value <- this.value + 2
  member this.incByOne () = base.inc () // inc by 1 implemented in base

let c1 = counter (0) // A counter by 1 starting with 0
printf "c1: %d" c1.value
c1.inc() // inc by 1
printfn " %d" c1.value
let c2 = counter2 (1) // A counter by 2 starting with 1
printf "c2: %d" c2.value
c2.inc() // inc by 2
printf " %d" c2.value
c2.incByOne() // inc by 1
printfn " %d" c2.value
