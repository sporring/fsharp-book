open System.Windows.Forms
open System.Drawing

///////////// Model /////////////
type Coord = float * float // any finite values
type Rgb = float * float * float // values 0.0 to 1.0
type Width = float // any positive value
type Tool = Rgb * Width // Pen name is take by System.Drawing
type Polygon = Coord list * Tool

/// Translate coordinates
let translate ((dx, dy) : Coord) (lst : Coord list) : Coord list =
  List.map (fun (x,y) -> (x + dx, y + dy)) lst

/// Rotate coordinates
let rotate (theta : float) (lst : Coord list) : Coord list =
  let rot t (x,y) = (x * cos t - y * sin t, x * sin t + y * cos t)
  List.map (rot theta) lst

/// Calculate the mass center of a list of points
let centerOfPoints (points : (float * float) list) =
  let add acc elm = (fst acc + fst elm, snd acc + snd elm)
  let sum = List.fold add (0.0,  0.0) points
  (fst sum / (float points.Length), snd sum / (float points.Length))

/// Generate repeated rotated point-color pairs
let rec rotatedLst points color width src dest nth n =
  if n > 0 then
    let newPoints =
      points
      |> translate (- fst src, - snd src)
      |> rotate ((float n) * nth)
      |> translate dest
    (newPoints, (color, width))
      :: (rotatedLst points color width src dest nth (n - 1))
  else
    []

// Setup drawing details
let size = (600.0, 600.0)
let points = [(0.0, 0.0); (10.0, 170.0); (320.0, 20.0); (0.0, 0.0)]
let src = centerOfPoints points
let dest = ((float (fst size)) / 2.0, (float (snd size)) / 2.0)
let n = 36;
let nth = (360.0 / (float n)) * (System.Math.PI / 180.0)
let orgPoints =
  points
  |> translate (fst dest - fst src, snd dest - snd src)
let polygLst =
  rotatedLst points (0.0,0.0,1.0) 1.0 src dest nth n
    @ [(orgPoints, ((1.0,0.0,0.0), 3.0))]

///////////// Connect layer between model and WinForm /////////////
let toInt = int << round
let coordsToPoints (lst : Coord list) =
  let coordToPoint (p : Coord) : Point =
    Point ((toInt << fst) p, (toInt << snd) p)
  lst
  |> List.map coordToPoint
  |> List.toArray
let penToDrawingPen ((col, width) : Tool) : Pen =
  let (r,g,b) = col
  let drawingCol = Color.FromArgb (toInt (255.0*r), toInt (255.0*g), toInt (255.0*b))
  new Pen (drawingCol, single width)
let pts = List.map (fun (c,p) -> (penToDrawingPen p, coordsToPoints c)) polygLst

///////////// WinForm specifics /////////////
// Open Window using WinForm and display turtle curve
let pen = new Pen (Color.Black, 1.0f)
let win = new Form ()
win.Text <- "Transforming polygons"
win.BackColor <- Color.White
win.ClientSize <- Size ((int << fst) size, (int << snd) size)
let repaintPoly (lst : (Pen * (Point [])) list) (e : PaintEventArgs) : unit =
  List.iter (fun (p : Pen, lst : Point []) -> e.Graphics.DrawLines (p,lst)) lst
win.Paint.Add (repaintPoly pts)
Application.Run win
