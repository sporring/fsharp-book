open System.Windows.Forms
open System.Drawing

let win = new Form () // Create a window
win.ClientSize <- Size (300, 300)

let button = new Button () // Make a button
win.Controls.Add button
button.Location <- new Point (20, 20)
button.Text <- "Click me"

let lbl = new Label () // Add a label
win.Controls.Add lbl
lbl.Location <- new Point (20, 60)
lbl.Text <- "A text label"

let chkbox = new CheckBox () // Add a check box
win.Controls.Add chkbox
chkbox.Location <- new Point (20, 100)

let pick = new DateTimePicker () // Add a date and time picker
win.Controls.Add pick
pick.Location <- new Point (20, 140)

let prgrss = new ProgressBar () // Show a progress bar
win.Controls.Add prgrss
prgrss.Location <- new Point (20, 180)
prgrss.Minimum <- 0
prgrss.Maximum <- 9
prgrss.Value <- 3

let rdbttn = new RadioButton () // Add a radio button
win.Controls.Add rdbttn
rdbttn.Location <- new Point (20, 220)

let txtbox = new TextBox () // Add a text input field
win.Controls.Add txtbox
txtbox.Location <- new Point (20, 260)
txtbox.Text <- "Type something"

Application.Run win // Show everything and start event-loop
