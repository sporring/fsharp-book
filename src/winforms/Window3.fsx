/// Open a window using winforms in Mono. The program opens a window
/// and draws a black triangle inside it. Wrap the display part in a
/// function and change coordinates to start in lower left corner.
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

let display(title: string, lst:(float*float) list, color:Color, (pw:int, ph:int)) =
    let f (width, height) (x,y) = Point (int (round x), height - int (round y))
    let pArr = Array.ofList (List.map (f (pw, ph)) lst)
    let pen = new Pen (color)
    let draw (g:Graphics) = g.DrawLines (pen, pArr)
    let panel = new Panel (Dock = DockStyle.Fill)
    let winSize = Size (pw, ph)
    let win = new Form (Text = title, ClientSize = winSize)

    panel.Paint.Add (fun e -> draw (e.Graphics))
    win.Controls.Add panel
    Application.Run win

let listOfPoints = [(0.0,0.0); (20.0,170.0); (320.0,30.0); (0.0,0.0)]
display("My third window", listOfPoints, Color.Black, (450, 350))
