/// <summary>Find x when 0 = ax^2+bx+c.</summary>
/// <param name="a">Quadratic coefficient.</param>
/// <param name="b">Linear coefficient.</param>
/// <param name="c">Constant coefficient.</param>
/// <param name="sgn">+1 or -1 indicating which solution is to be calculated.</param>
/// <returns>x.</returns>
let solution a b c sgn =
  /// Calculate the determinant of a quadratic equation with parameters a, b, and c
  let determinant a b c =
    b ** 2.0 - 2.0 * a * c
  let d = determinant a b c
  (-b + sgn * sqrt d) / (2.0 * a)

let a = 1.0
let b = 0.0
let c = -1.0
let xp = solution a b c +1.0
printfn "%.1fx^2 + %.1fx+%.1f=0 => x=%.1f" a b c xp
