/// A button event
let buttonClicked (e : System.EventArgs) =
  ignore (System.Windows.Forms.MessageBox.Show "You clicked the button.")

// Create a button
let button = new System.Windows.Forms.Button ()
button.Size <- new System.Drawing.Size (100, 40)
button.Location <- new System.Drawing.Point (20, 20)
button.Text <- "Click me"
button.Click.Add buttonClicked

// Create a window and add button
let win = new System.Windows.Forms.Form ()
win.Controls.Add button

// Start the event-loop.
System.Windows.Forms.Application.Run win
