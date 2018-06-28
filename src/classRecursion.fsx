type twice (v : int) = 
  static member fac n = if n > 1 then n * (twice.fac (n-1)) else 1 // No rec §\label{classRecursionNoRec}§
  member this.copy = this.twice // No lexicographical scope §\label{classRecursionNoLexOrder}§
  member this.twice = 2*v

let a = twice (2)
let b = twice.fac 3  
printfn "%A %A %A" a.copy a.twice b
