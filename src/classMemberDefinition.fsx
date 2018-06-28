type Test () =
  let letV = 0
  [<DefaultValue>] val mutable valMutableV : int // Discouraged
  let mutable letMutableV = 0
  member val memberValV = 0 // Discouraged
  member this.memberThisV = 0
  member mutable this.memberMutableThisV = 0 // Error, mutable members are illegal
  member val memberValGetV = 0 with get
  member val memberValSetV = 0 with set // Error, must have get
  member val memberValGetSetV = 0 with get, set
  member this.memberThisGetV
    with get () = letMutableV // Read from object variable 
  member this.memberThisSetV
    with set (value) = letMutableV <- value // Save to object variable
  member this.memberThisGetSetV
    with get () = letMutableV // Read from object variable
    and set (value) = letMutableV <- value // Save to object variable

let t = Test ()
printfn "%A" t.letV // Error: internal
t.letV <- 1 // Error: internal
printfn "%A" t.valMutableV
t.valMutableV <- 1
printfn "%A" t.letMutableV // Error: internal
t.letMutableV <- 1 // Error: internal
printfn "%A" t.memberValV
t.memberValV <- 1 // Error: read-only
printfn "%A" t.memberThisV
t.memberThisV <- 1 // Error: read-only
printfn "%A" t.memberValGetV
t.memberValGetV <- 1 // Error: read-only
printfn "%A" t.memberValGetSetV
t.memberValGetSetV <- 1
printfn "%A" t.memberThisGetV
t.memberThisGetV <- 1 // Error: read-only
printfn "%A" t.memberThisSetV // Error: write-only
t.memberThisSetV <- 1
printfn "%A" t.memberThisGetSetV
t.memberThisGetSetV <- 1
