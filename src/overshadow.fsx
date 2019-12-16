type person (name : string) =
  member this.name = name
  member this.introduction = "I'm " + name
type teacher (name : string) =
  inherit person(name)
  member this.introduction = "I'm Prof. " + name

let p = person ("Hans")
printfn "%s" p.introduction
let t = teacher ("Jon")
printfn "%s" t.introduction
let tp = t :> person
printfn "%s" tp.introduction
let tpt = tp :?> teacher
printfn "%s" tpt.introduction

