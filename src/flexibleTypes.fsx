type Holder() =
  let mutable _value = Base()
  member this.value
    with get() = _value
    and set(v : Base) = _value <- v
and Base() =
  let mutable _str = "hej"
  member this.str
    with get() = _str
    and set(v) = _str <- v
type Deriv1() =
  inherit Base()
  member this.one = "hej"
type Deriv2() =
  inherit Base()
  member this.two = "good bye"
let a = Holder()
printfn "%A" a.value
a.value <- Deriv1()
printfn "%A" a.value
printfn "%A" (a.value :?> Deriv1).one
a.value <- (Deriv2() :> Base)
printfn "%A" a.value
printfn "%A" (a.value :?> Deriv2).two
