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
  let question = "Is this statement false?"
  let caption = "Window caption"
  let boxType = MessageBoxButtons.YesNo
  let response = MessageBox.Show (question, caption, boxType)
  printfn "The user pressed %A" response
button.Click.Add buttonClicked

Application.Run win
