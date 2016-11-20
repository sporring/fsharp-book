open System.Drawing
open System.Windows.Forms

// Initialize a form containing a panel, textbox, and a label
let win = new Form ()
let panel = new Panel ()
let textBox = new TextBox ()
let label = new Label ()

// Customize the window
win.Text <- "Window with a panel"
win.ClientSize <- new Size (400, 300)

// Customize the Panel control
panel.Location <- new Point (56,72)
panel.Size <- new Size (264, 152)
panel.BorderStyle <- BorderStyle.Fixed3D

// Customize the Label and TextBox controls
label.Location <- new Point (16,16)
label.Text <- "label"
label.Size <- new Size (104, 16)
textBox.Location <- new Point (16,32)
textBox.Text <- "Initial text"
textBox.Size <- new Size (152, 20)

// Add panel to window and label and textBox to panel
win.Controls.Add panel
panel.Controls.Add label
panel.Controls.Add textBox

// Start the event-loop
Application.Run win
