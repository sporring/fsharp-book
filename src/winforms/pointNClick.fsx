open System.Windows.Forms
open System.Drawing
open System

type coordinates = (int * int) list
type pen = Color * float

// Paint event handler
let drawPoints (pen : pen) (coords : coordinates ref) (e : PaintEventArgs) =
  if (!coords).Length > 1 then
    let color, width = pen
    let Pen = new Pen (color, single width)
    let Points = Array.map (fun (x, y) -> Point (x,y)) (List.toArray !coords)
    e.Graphics.DrawLines (Pen, Points)

// Mouse event handler
let mouseClick (coords : coordinates ref) (win : Form) (e : MouseEventArgs) =
  coords := (e.Location.X, e.Location.Y) :: !coords
  win.Refresh ()

// Keyboard event handler
let keyPress (coords : coordinates ref) (win : Form) (e : KeyPressEventArgs) =
  if (e.KeyChar.ToString ()) = "d" && (!coords).Length > 0 then
    coords := (!coords).[1..]
    win.Refresh ()

let createForm backgroundColor (width, height) title paint mouseClick keyPress =
  let win = new Form ()
  win.Text <- title
  win.BackColor <- backgroundColor
  win.ClientSize <- Size (width, height)
  win.Paint.Add paint
  win.MouseClick.Add (mouseClick win)
  win.KeyPreview <- true
  win.KeyPress.Add (keyPress win)
  win

// Global variables
let coords = ref ([] : coordinates)

// create a form
let title = "Click to add points"
let backgroundColor = Color.White
let size = (400, 200)
let pen = (Color.Black, 1.0)

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints pen coords) (mouseClick coords) (keyPress coords)
Application.Run win
