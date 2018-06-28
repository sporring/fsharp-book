[<AbstractClass>]
type aCounter(init : int) =
  let mutable i = init
  member this.value with get() = i and set(v) = i <- v
  abstract member inc: unit -> unit
type counter(init : int) =
  inherit aCounter(init)
  override this.inc() = this.value <- this.value + 1
type counter2(init : int) =
  inherit aCounter(init)
  override this.inc() = this.value <- this.value + 2

let c1 = counter(0)
printf "c1: %d" c1.value
c1.inc()
printfn " %d" c1.value
let c2 = counter2(1)
printf "c2: %d" c2.value
c2.inc()
printf " %d" c2.value
