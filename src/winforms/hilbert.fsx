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

type curve = float * float * coordinates

/// Turn 90 degrees left
let left (l, dir, c) : curve = (l, dir + 3.141592/2.0, c)

/// Turn 90 degrees right
let right (l, dir, c) : curve = (l, dir - 3.141592/2.0, c)

/// Add a line to the curve of present direction
let forward (l, dir, c) : curve =
  let nextPoint = rotatePoint dir (l, 0.0)
  (l, dir, c @ [translatePoint c.[c.Length-1] nextPoint])

/// Find the maximum value of each coordinate element in a list
let maximum (c : coordinates) =
  let maxPoint p1 p2 =
    (max (fst p1) (fst p2), max (snd p1) (snd p2))
  List.fold maxPoint (-infinity, -infinity) c

/// Hilbert recursion production rules
let rec ruleA n C : curve =
  if n > 0 then
    (C |> left |> ruleB (n-1) |> forward |> right |> ruleA (n-1) |> forward |> ruleA (n-1) |> right |> forward |> ruleB (n-1) |> left)
  else
    C
and ruleB n C : curve = 
  if n > 0 then
    (C |> right |> ruleA (n-1) |> forward |> left |> ruleB (n-1) |> forward |> ruleB (n-1) |> left |> forward |> ruleA (n-1) |> right)
  else
    C

// Calculate curve
let order = 5
let l = 20.0
let (_, dir, c) = ruleA order (l, 0.0, [(0.0, 0.0)])

// Setup drawing details
let title = "Hilbert's curve"
let backgroundColor = Color.White
let cMax = maximum c
let size = (int (fst cMax)+1, int (snd cMax)+1)
let polygLst = [(c, (Color.Black, 3.0))]

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints polygLst) 
Application.Run win
