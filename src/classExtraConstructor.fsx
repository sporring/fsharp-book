type classExtraConstructor (name : string, greetings : string) =
  static let defaultGreetings = "Hello"
 // Additional constructor are defined by new () §\label{classExtraConstructorStart}§
  new (name : string) = 
    classExtraConstructor (name, defaultGreetings) (*//§\label{classExtraConstructorEnd}§*)
  member this.name = name
  member this.str = greetings + " " + name

let s = classExtraConstructor ("F#") // Calling additional constructor §\label{classExtraConstructorAddApp}§
let t = classExtraConstructor ("F#", "Hi") // Calling primary constructor §\label{classExtraConstructorPrimApp}§
printfn "%A, %A" s.str t.str
