// Create a window
let win = new System.Windows.Forms.Form ()
// Set some properties
win.BackColor <- System.Drawing.Color.White
win.Size <- System.Drawing.Size (600, 200)
win.Text <- sprintf "This has color %A and size %A" win.BackColor win.Size
// Start the event-loop.
System.Windows.Forms.Application.Run win
