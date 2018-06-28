type student (name : string) = 
  static let mutable nextAvailableID = 0 // A global id for all objects §\label{classStaticStaticField}§
  let studentID = nextAvailableID // A per object id §\label{classStaticNonStaticField}§
  do nextAvailableID <- nextAvailableID + 1
  member this.id with get () = studentID
  member this.name = name
  static member nextID = nextAvailableID // A global member §\label{classStaticStaticMemeber}§
let a = student ("Jon") // Students will get unique ids, when instantiated
let b = student ("Hans")
printfn "%s: %d,  %s: %d" a.name a.id  b.name b.id
printfn "Next id: %d" student.nextID // Accessing the class's member §\label{classStaticStaticAccess}§
