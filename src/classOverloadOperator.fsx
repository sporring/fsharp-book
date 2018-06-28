type anInt (v : int) = 
  member this.value = v
  static member (+) (v : anInt, w : anInt) = anInt (v.value + w.value)
  static member (~-) (v : anInt) = anInt (-v.value)
and aFloat (w : float) = 
  member this.value = w
  static member (+) (v : aFloat, w : aFloat) = aFloat (v.value + w.value)
  static member (+) (v : anInt, w : aFloat) =
    aFloat ((float v.value) + w.value)
  static member (+) (w : aFloat, v : anInt) = v + w // reuse def. above
  static member (~-) (v : aFloat) = aFloat (-v.value)

let a = anInt (2)
let b = anInt (3)
let c = aFloat (3.2)
let d = a + b // anInt + anInt
let e = c + a // aFloat + anInt
let f = a + c // anInt + aFloat
let g = -a // unitary minus anInt
let h = a + -b // anInt + unitary minus anInt
printf "a=%A, b=%A, c=%A, d=%A" a.value b.value c.value d.value
printf ", e=%A, f=%A, g=%A, h=%A" e.value f.value g.value h.value
