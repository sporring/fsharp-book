open System.Windows.Forms
open System.Drawing

let win = new Form ()
win.ClientSize <- Size (300, 200)

let ctrl = new DateTimePicker ()
win.Controls.Add ctrl
ctrl.Location <- new Point (20, 20)

Application.Run win
