type Test () =
  static let staticLetV = 0
  [<DefaultValue>] static val mutable staticValMutableV : int // Error: public static variables not allowed
  static let mutable staticLetMutableV = 0
  static member val staticMemberValV = 0 // Discouraged
  static member staticMemberV = 0
  static member mutable staticMemberMutableThisV = 0 // Error, mutable members are illegal
  static member val staticMemberValGetSetV = 0 with get, set
  static member staticMemberGetSetV
    with get() = 0 
    and set(value) = staticLetMutableV <- value // Save to class variable
printfn "%A" Test.staticLetV // Error: internal
Test.staticLetV <- 1 // Error: internal
printfn "%A" Test.staticLetMutableV // Error: internal
Test.staticLetMutableV <- 1 // Error: internal
printfn "%A" Test.staticMemberValV
Test.staticMemberValV <- 1 // Error: read-only
printfn "%A" Test.staticMemberV
Test.staticMemberV <- 1 // Error: read-only
printfn "%A" Test.staticMemberValGetSetV
Test.staticMemberValGetSetV <- 1
printfn "%A" Test.staticMemberGetSetV
Test.staticMemberGetSetV <- 1
