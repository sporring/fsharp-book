type anInt (v : int) = 
  member this.value = v
  member this.add (w : aFloat) : aFloat = aFloat ((float this.value) + w.value)
and aFloat (w : float) = 
  member this.value = w
  member this.add (v : anInt) : aFloat = aFloat ((float v.value) + this.value)
let a = anInt (2)
let b = aFloat (3.2)
let c = a.add b
let d = b.add a
printfn "%A %A %A %A" a.value b.value c.value d.value
