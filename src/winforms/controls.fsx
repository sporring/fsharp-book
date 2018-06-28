open System.Windows.Forms
open System.Drawing

let win = new Form ()
win.ClientSize <- Size (300, 300)

let button = new Button ()
win.Controls.Add button
button.Location <- new Point (20, 20)
button.Text <- "Click me"

let lbl = new Label ()
win.Controls.Add lbl
lbl.Location <- new Point (20, 60)
lbl.Text <- "A text label"

let chkbox = new CheckBox ()
win.Controls.Add chkbox
chkbox.Location <- new Point (20, 100)

let pick = new DateTimePicker ()
win.Controls.Add pick
pick.Location <- new Point (20, 140)

let prgrss = new ProgressBar ()
win.Controls.Add prgrss
prgrss.Location <- new Point (20, 180)
prgrss.Minimum <- 0
prgrss.Maximum <- 9
prgrss.Value <- 3

let rdbttn = new RadioButton ()
win.Controls.Add rdbttn
rdbttn.Location <- new Point (20, 220)

let txtbox = new TextBox ()
win.Controls.Add txtbox
txtbox.Location <- new Point (20, 260)
txtbox.Text <- "Type something"

Application.Run win
