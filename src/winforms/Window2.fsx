/// Open a window using winforms in Mono. The program opens a window
/// and draws a black triangle inside it. Wrap the display part in a function.
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

let display(title: string, lst:(float*float) list, color:Color) =
    let f(x,y) = Point (int (round x), int(round y))
    let pArr = Array.ofList (List.map f lst)
    let pen = new Pen (color)
    let draw (g:Graphics) = g.DrawLines (pen, pArr)
    let panel = new Panel (Dock = DockStyle.Fill)
    let win = new Form (Text = title)

    panel.Paint.Add (fun e -> draw (e.Graphics))
    win.Controls.Add panel
    Application.Run win

let listOfPoints = [(0.0,0.0); (10.0,170.0); (320.0,20.0); (0.0,0.0)]
display("My second window", listOfPoints, Color.Black)
