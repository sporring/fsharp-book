type classMutable (name : string) =
  static let mutable greetings = "Hello" (*//§\label{classStaticMutableVar}§*)
  member this.name = name
  // Define getters and setters for the private variable §\label{classStaticMutableGetSetStart}§
  static member setGreetings(aGreeting: string) =
    greetings <- aGreeting
  static member getGreetings() =
    greetings  (*//§\label{classStaticMutableGetSetEnd}§*)
  override this.ToString() =
    greetings + " " + name

let s = classMutable("F#")
classMutable.setGreetings("Hi") (*//§\label{classStaticMutableSetApp}§*)
printfn "\"%A\", \"%A\"" s (classMutable.getGreetings()) (*//§\label{classStaticMutableGetApp}§*)
