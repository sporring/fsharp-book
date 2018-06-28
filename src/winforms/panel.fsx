open System.Drawing
open System.Windows.Forms

let win = new Form () // Create a window form
win.ClientSize <- new Size (200, 100)

// Customize the Panel control
let panel = new Panel ()
panel.ClientSize <- new Size (160, 60)
panel.Location <- new Point (20,20)
panel.BorderStyle <- BorderStyle.Fixed3D
win.Controls.Add panel // Add panel to window

// Customize the Label and TextBox controls
let label = new Label ()
label.ClientSize <- new Size (120, 20)
label.Location <- new Point (15,5)
label.Text <- "Input"
panel.Controls.Add label // add label to panel

let textBox = new TextBox ()
textBox.ClientSize <- new Size (120, 20)
textBox.Location <- new Point (20,25)
textBox.Text <- "Initial text"
panel.Controls.Add textBox // add textbox to panel

Application.Run win // Start the event-loop
