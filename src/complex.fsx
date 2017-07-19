type complex(aReal,anImaginary) =
  member this.re = aReal
  member this.im = anImaginary
  member this.add (a : complex) : complex = 
    new complex(this.re + a.re, this.im + a.im)

let x = new complex(1.0,2.0)
let y = new complex(2.5,-1.2)
let z = x.add(y)
printfn "(%A, %A) + (%A, %A) = (%A, %A)" x.re x.im y.re y.im z.re z.im
