open System.Windows.Forms
open System.Drawing

type coordinates = (float * float) list
type pen = Color * float
type polygon = coordinates * pen

/// Create a form and add a paint function
let createForm backgroundColor (width, height) title draw =
  let win = new Form ()
  win.Text <- title
  win.BackColor <- backgroundColor
  win.Size <- Size (width, height)
  win.Paint.Add draw
  win

/// Draw a polygon with a specific color
let drawPoints (polygLst : polygon list) (e : PaintEventArgs) =
  let pairToPoint (x : float, y : float) =
    Point (int (round x), int (round y))

  for polyg in polygLst do
    let coords, (color, width) = polyg
    let pen = new Pen (color, single width)
    let Points = Array.map pairToPoint (List.toArray coords)
    e.Graphics.DrawLines (pen, Points)
    
/// Translate point array
let translatePoints (dx, dy) arr =
  let translatePoint (dx, dy) (x, y) =
    (x + dx, y + dy)
  List.map (translatePoint (dx, dy)) arr

/// Rotate point array
let rotatePoints theta arr =
  let rotatePoint theta (x, y) =
    (x * cos theta - y * sin theta, x * sin theta + y * cos theta)
  List.map (rotatePoint theta) arr

/// Calculate the mass center of a list of points
let centerOfPoints (points : (float * float) list) =
  let addToAccumulator acc elm = (fst acc + fst elm, snd acc + snd elm)
  let sum = List.fold addToAccumulator (0.0,  0.0) points
  (fst sum / (float points.Length), snd sum / (float points.Length))

/// Generate repeated rotated point-color pairs
let rec rotatedLst points color width src dest nth n =
  if n > 0 then
    let newPoints =
      points
      |> translatePoints (- fst src, - snd src)
      |> rotatePoints ((float n) * nth)
      |> translatePoints dest
    (newPoints, (color, width))
      :: (rotatedLst points color width src dest nth (n - 1))
  else
    []

// Setup drawing details
let title = "Rotational Symmetry"
let backgroundColor = Color.White
let size = (600, 600)
let points = [(0.0, 0.0); (10.0, 170.0); (320.0, 20.0); (0.0, 0.0)]
let src = centerOfPoints points
let dest = ((float (fst size)) / 2.0, (float (snd size)) / 2.0)
let n = 36;
let nth = (360.0 / (float n)) * (System.Math.PI / 180.0)
let orgPoints =
  points
  |> translatePoints (fst dest - fst src, snd dest - snd src)
let polygLst =
  rotatedLst points Color.Blue 1.0 src dest nth n
    @ [(orgPoints, (Color.Red, 3.0))]

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints polygLst) 
Application.Run win
