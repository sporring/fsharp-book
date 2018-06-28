// file: glade.cs
using System;
using Gtk;
using Glade;
public class GladeApp
{
        public static void Main (string[] args)
        {
                new GladeApp (args);
        }
 
        public GladeApp (string[] args)
        {
                Application.Init();
 
                Glade.XML gxml = new Glade.XML (null, "gui.glade", "window1", null);
                gxml.Autoconnect (this);
                Application.Run();
        }
}