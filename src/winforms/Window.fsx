/// Open a window using winforms in Mono. The program opens a window
/// and draws a black triangle inside it.
///
/// How to compile:
/// <code>
/// fsharpc Window.fsx
/// </code>
///
/// Author: Jon Sporring.
/// Date: 2015/11/19

open System.Drawing
open System.Windows.Forms

/// Set parameters for drawing.
let penColor = Color.Black
let listOfPoints = [Point (0,0); Point (10,170); Point (320,20); Point (0,0)]

/// Convert list of points to an array, create a pen, and create the
/// panel data structure and add its draw function.
let pArr = Array.ofList listOfPoints
let pen = new Pen (penColor)
let panel = new Panel (Dock = DockStyle.Fill)
panel.Paint.Add (fun e -> e.Graphics.DrawLines (pen, pArr))

/// Create the window data structure and add its panel.
let win = new Form ()
win.Controls.Add panel

/// Create the window and turn over control to the operating
/// system. Use "win.Show()" on Microsoft Windows instead.
Application.Run win
