namespace Utilities
type floatFunction = float -> float -> float
module Meta = 
  let apply (f : floatFunction) (x : float) (y : float) : float = f x y