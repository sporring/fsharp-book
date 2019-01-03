open System.Windows.Forms
open System.Drawing
open System

let win = new Form ()
win.ClientSize <- Size (140, 80)

let button = new Button ()
win.Controls.Add button
button.Size <- new Size (100, 40)
button.Location <- new Point (20, 20)
button.Text <- "Click me"
// Open a message box when button clicked
let buttonClicked (e : EventArgs) =
  let opendlg = new OpenFileDialog()
  let okOrCancel = opendlg.ShowDialog()
  printfn "The user pressed %A and selected %A" okOrCancel opendlg.FileName
button.Click.Add buttonClicked

Application.Run win
