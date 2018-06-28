type classExtraConstructor(x : float, y : float, leftBrk : string, sep : string, rightBrk : string) =
  static let defaultLeftBracket = "("
  static let defaultRightBracket = ")"
  static let defaultSeparator = ", "
  let hej = "hej"
  do printfn "New classExtraConstructor with (%A, %A, %A, %A, %A)" x y leftBrk sep rightBrk
  new() as alsoThis = 
    do printfn "New empty constructor of classExtraConstructor"
    classExtraConstructor(0.0, 0.0, defaultLeftBracket, defaultSeparator, defaultRightBracket)
    then 
      printfn "Construction done %A" alsoThis.test
    
  new(x : float, y : float) = 
    do printfn "New half empty constructor of classExtraConstructor"
    classExtraConstructor(x, y, defaultLeftBracket, defaultSeparator, defaultRightBracket)
  member this.x = (x,y)
  member this.test() = hej + (string this.x)
  override this.ToString() =
    sprintf "%s%A%s%A%s" leftBrk (fst this.x) sep (snd this.x) rightBrk

let u = classExtraConstructor()
let v = classExtraConstructor(1.0, 2.0)
let w = classExtraConstructor(1.0, 2.0, "[", "; ", "]")
printfn "%A, %A, %A" u v w
