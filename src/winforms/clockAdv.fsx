open System.Windows.Forms    
open System.Drawing   
open System  

// create forms, controls, and timer, and link them
let timer = new Timer()
let clock = new Form ()
let panel = new TableLayoutPanel ()
let label = new Label()  
let button = new Button ()
panel.Controls.Add(label)  
panel.Controls.Add(button)  
clock.Controls.Add panel

// customize window
clock.Text <- "Time"
clock.ClientSize <- Size (100,100)

// customize panel
panel.ColumnCount <- 1
panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
panel.Dock <- DockStyle.Fill

// customize timer text
label.Font <- new Font("Arial", 14.5F)
label.Margin <- Padding 10

// customize exit button
button.Text<-"Exit"
button.BackColor<-Color.Ivory
let exit (timer : Timer) (form : Form) _ =
  timer.Stop()
  form.Close()
button.Click.Add (exit timer clock)
button.Margin <- Padding 10
button.Anchor <- AnchorStyles.None

// make a timer and link to label
timer.Interval <- 1000
timer.Enabled <- true  
let setTime (label : Label) showtime =
  let time = string System.DateTime.Now
  label.Text <- time.[11..]
timer.Tick.Add (setTime label)
setTime label ()

// start event-loop
Application.Run clock  
