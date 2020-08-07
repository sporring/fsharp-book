type coordinate(pos : int * int) =
  let mutable _p = pos // mutable makes fsharpi crash!
  member this.elm with get() = _p and set(p) = _p <- p
let pieces = [| coordinate((0,0)) |]
