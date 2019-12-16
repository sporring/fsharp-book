[<AbstractClass>]
type person (name : string) =
  member this.name = name
  abstract member introduction : string
type teacher (name : string) =
  inherit person(name)
  override this.introduction = "I'm Prof. " + name

let t = teacher ("Jon")
printfn "%s" t.introduction
let tp = t :> person
printfn "%s" tp.introduction
let tpt = tp :?> teacher
printfn "%s" tpt.introduction

