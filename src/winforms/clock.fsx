open System  
open System.Drawing   
open System.Windows.Forms    

// create forms, controls, and timer, and link them
let clock = new Form ()
let panel = new TableLayoutPanel ()
let lbltime = new Label()  
let timeobject = new Timer()
let exitbutton = new Button ()
panel.Controls.Add(lbltime)  
panel.Controls.Add(exitbutton)  
clock.Controls.Add panel

// customize window
clock.Text <- "Time"
clock.ClientSize <- Size (100,100)

// customize panel
panel.ColumnCount <- 1
panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
panel.Dock <- DockStyle.Fill

// customize timer text
lbltime.Font <- new Font("Arial", 14.5F)
lbltime.Margin <- Padding 10

// customize timer
timeobject.Interval <- 1000
timeobject.Enabled <- true  
let setTime (label : Label) showtime =
  let time = string System.DateTime.Now
  label.Text <- time.[11..]
timeobject.Tick.Add (setTime lbltime)
setTime lbltime ()

// customize exit button
exitbutton.Text<-"Exit"
exitbutton.BackColor<-Color.Ivory
let exit (timer : Timer) (form : Form) _ =
  timer.Stop()
  form.Close()
exitbutton.Click.Add (exit timeobject clock)
exitbutton.Margin <- Padding 10
exitbutton.Anchor <- AnchorStyles.None

// start event-loop
Application.Run clock  
