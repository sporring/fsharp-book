type vectorWToString (x : float, y : float) =
  member this.x = (x,y)
  // Custom printing of objects by overriding this.ToString() §\label{classToStringStart}§
  override this.ToString() =
    sprintf "(%A, %A)" (fst this.x) (snd this.x) (*//§\label{classToStringEnd}§*)

let v = vectorWToString(1.0, 2.0)
printfn "%A" v // No change in application but result is better §\label{classToStringApp}§
