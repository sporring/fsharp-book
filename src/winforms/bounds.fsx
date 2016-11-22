open System.Drawing
open System.Windows.Forms

// Initialize a form 
let win = new Form ()
win.Text <- "Window with a panel"
win.ClientSize <- new Size (300, 300)

// Set the button size and location using 
// the Size and Location properties.
let buttonOK = new Button ()
buttonOK.Location <- new Point (136,248)
buttonOK.Size <- new Size (75,25)
buttonOK.Text <- "OK"

// Set the button size and location using the Top, 
// Left, Width, and Height properties.
let buttonCancel = new Button ()
buttonCancel.Top <- buttonOK.Top
buttonCancel.Left <- buttonOK.Right + 5
buttonCancel.Width <- buttonOK.Width
buttonCancel.Height <- buttonOK.Height
buttonCancel.Text <- "Cancel"

// Set the button size and location using 
// the Bounds property.
let buttonHelp = new Button ()
buttonHelp.Bounds <- new Rectangle (10,10, 75, 25)
buttonHelp.Text <- "Help"

// Add the buttons to the form and start the event-loop
win.Controls.AddRange [|buttonOK; buttonCancel; buttonHelp|]
Application.Run win
