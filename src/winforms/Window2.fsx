/// Open a window using winforms in Mono. The program opens a window
/// and draws a black triangle inside it. Wrap the display part in a function.

open System.Drawing
open System.Windows.Forms

let display (title: string) (lst:(float*float) []) (color:Color) =
    let f(x,y) = Point (int (round x), int(round y))
    let pArr = Array.map f lst
    let pen = new Pen (color)
    let draw (g:Graphics) = g.DrawLines (pen, pArr)
    let win = new Form (Text = title)
    win.Paint.Add (fun e -> draw (e.Graphics))
    Application.Run win

let listOfPoints = [|(0.0,0.0); (10.0,170.0); (320.0,20.0); (0.0,0.0)|]
display "My second window", listOfPoints, Color.Black
