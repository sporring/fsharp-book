open System.Windows.Forms

let Form1 = new Form ()
let components = new System.ComponentModel.Container()
let tabPage1 = new System.Windows.Forms.TabPage()
let tab2CheckBox3 = new System.Windows.Forms.CheckBox()
let tab3RadioButton2 = new System.Windows.Forms.RadioButton()
let tabControl1 = new System.Windows.Forms.TabControl()
let tab2CheckBox2 = new System.Windows.Forms.CheckBox()
let tab2CheckBox1 = new System.Windows.Forms.CheckBox()
let tab3RadioButton1 = new System.Windows.Forms.RadioButton()
let tab1Label1 = new System.Windows.Forms.Label()
let tabPage3 = new System.Windows.Forms.TabPage()
let tabPage2 = new System.Windows.Forms.TabPage()
let tab1Button1 = new System.Windows.Forms.Button()

Form1.Text = "Form1"
tabPage1.Text <- "tabPage1"
tabPage1.Size <- new System.Drawing.Size(256, 214)
tabPage1.TabIndex <- 0
tab2CheckBox3.Location <- new System.Drawing.Point(32, 136)
tab2CheckBox3.Text <- "checkBox3"
tab2CheckBox3.Size <- new System.Drawing.Size(176, 32)
tab2CheckBox3.TabIndex <- 2
tab2CheckBox3.Visible <- true
tab3RadioButton2.Location <- new System.Drawing.Point(40, 72)
tab3RadioButton2.Text <- "radioButton2"
tab3RadioButton2.Size <- new System.Drawing.Size(152, 24)
tab3RadioButton2.TabIndex <- 1
tab3RadioButton2.Visible <- true
tabControl1.Location <- new System.Drawing.Point(16, 16)
tabControl1.Size <- new System.Drawing.Size(264, 240)
tabControl1.SelectedIndex <- 0
tabControl1.TabIndex <- 0
tab2CheckBox2.Location <- new System.Drawing.Point(32, 80)
tab2CheckBox2.Text <- "checkBox2"
tab2CheckBox2.Size <- new System.Drawing.Size(176, 32)
tab2CheckBox2.TabIndex <- 1
tab2CheckBox2.Visible <- true
tab2CheckBox1.Location <- new System.Drawing.Point(32, 24)
tab2CheckBox1.Text <- "checkBox1"
tab2CheckBox1.Size <- new System.Drawing.Size(176, 32)
tab2CheckBox1.TabIndex <- 0
tab3RadioButton1.Location <- new System.Drawing.Point(40, 32)
tab3RadioButton1.Text <- "radioButton1"
tab3RadioButton1.Size <- new System.Drawing.Size(152, 24)
tab3RadioButton1.TabIndex <- 0
tab1Label1.Location <- new System.Drawing.Point(16, 24)
tab1Label1.Text <- "label1"
tab1Label1.Size <- new System.Drawing.Size(224, 96)
tab1Label1.TabIndex <- 1
tabPage3.Text <- "tabPage3"
tabPage3.Size <- new System.Drawing.Size(256, 214)
tabPage3.TabIndex <- 2
tabPage2.Text <- "tabPage2"
tabPage2.Size <- new System.Drawing.Size(256, 214)
tabPage2.TabIndex <- 1
tab1Button1.Location <- new System.Drawing.Point(88, 144)
tab1Button1.Size <- new System.Drawing.Size(80, 40)
tab1Button1.TabIndex <- 0
tab1Button1.Text <- "button1"
let tab1Button1_Click (e : System.EventArgs) = ()
tab1Button1.Click.Add (fun e -> tab1Button1_Click e)

// Adds controls to the second tab page.
tabPage2.Controls.Add(tab2CheckBox3)
tabPage2.Controls.Add(tab2CheckBox2)
tabPage2.Controls.Add(tab2CheckBox1)
// Adds controls to the third tab page.
tabPage3.Controls.Add(tab3RadioButton2)
tabPage3.Controls.Add(tab3RadioButton1)
// Adds controls to the first tab page.
tabPage1.Controls.Add(tab1Label1)
tabPage1.Controls.Add(tab1Button1)
// Adds the TabControl to the form.
Form1.Controls.Add(tabControl1)
// Adds the tab pages to the TabControl.
tabControl1.Controls.Add(tabPage1)
tabControl1.Controls.Add(tabPage2)
tabControl1.Controls.Add(tabPage3)

Application.Run Form1
