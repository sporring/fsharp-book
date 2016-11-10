/// Open a window using winforms in Mono. The program opens a window
/// and draws a black triangle inside it.
open System.Drawing
open System.Windows.Forms

// Choose some points and a color
let Points = [|Point (0,0); Point (10,170); Point (320,20); Point (0,0)|]
let penColor = Color.Black

// Setup drawing function
let pen = new Pen (penColor)
let win = new Form ()
win.Paint.Add (fun e -> e.Graphics.DrawLines (pen, Points))

// Create the window and turn over control to the operating
// system. Use "win.Show()" on Microsoft Windows instead.
Application.Run win
