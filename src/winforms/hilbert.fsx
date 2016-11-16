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
  win.ClientSize <- Size (width, height)
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
    
/// Translate a point
let translatePoint (dx, dy) (x, y) =
  (x + dx, y + dy)

/// Translate point array
let translatePoints (dx, dy) arr =
  List.map (translatePoint (dx, dy)) arr

/// Rotate a point
let rotatePoint theta (x, y) =
  (x * cos theta - y * sin theta, x * sin theta + y * cos theta)

/// Rotate point array
let rotatePoints theta arr =
  List.map (rotatePoint theta) arr

/// Turn 90 degrees left
let turnLeft (l, dir, c) = (l, dir + 3.141592/2.0, c)

/// Turn 90 degrees right
let turnRight (l, dir, c) = (l, dir - 3.141592/2.0, c)

/// Add a line to the curve of present direction
let draw (l, dir, (c : coordinates)) =
  let nextPoint = rotatePoint dir (l, 0.0)
  (l, dir, c @ [translatePoint c.[c.Length-1] nextPoint])

/// Find the maximum value of each coordinate element in a list
let maximum c =
  let maxPoint (p1 : float*float) (p2 : float*float) =
    (max (fst p1) (fst p2), max (snd p1) (snd p2))
  List.fold maxPoint (-infinity, -infinity) c    

/// Hilbert recursion production rules
let rec hilbertA n (l, dir, c) =
  if n > 0 then
    ((l, dir, c) |> turnLeft |> hilbertB (n-1) |> draw |> turnRight |> hilbertA (n-1) |> draw |> hilbertA (n-1) |> turnRight |> draw |> hilbertB (n-1) |> turnLeft)
  else
    (l, dir, c)
and hilbertB n (l, dir, c) = 
  if n > 0 then
    ((l, dir, c) |> turnRight |> hilbertA (n-1) |> draw |> turnLeft |> hilbertB (n-1) |> draw |> hilbertB (n-1) |> turnLeft |> draw |> hilbertA (n-1) |> turnRight)
  else
    (l, dir, c)

// Calculate curve
let order = 5
let l = 20.0
let (_, dir, C) = hilbertA order (l, 0.0, [(0.0, 0.0)])

// Setup drawing details
let title = "Hilbert's curve"
let backgroundColor = Color.White
let cMax = maximum C
let size = (int (fst cMax)+1, int (snd cMax)+1)
let polygLst = [(C, (Color.Black, 3.0))]

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints polygLst) 
System.Windows.Forms.Application.Run win
