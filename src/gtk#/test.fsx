namespace Test

module Main =
    open System
    open Gtk

    type UIResource = 
        | File of string
        | Embedded of string

    let NewBuilder (resource : UIResource) =
        match resource with
        | File f -> use fs = new IO.FileStream(f, IO.FileMode.Open)
                    new Builder(fs)
        | Embedded e -> new Builder(e)

    [<AbstractClass>]
    type BuilderWindow(resource) =
        abstract builder : Builder
        default this.builder = NewBuilder resource

    type MainWindow(resource) as this = 
        inherit BuilderWindow(resource)

        // autoconnect widgets
        [<Builder.Object>]
        let windownode : Window = null

        // remove this to get a System.NullReferenceException
        let what() = windownode

        // autoconnect event handlers
        let windownode_delete (o : Object, args : DeleteEventArgs) = 
            Application.Quit()
            args.RetVal <- true

        do 
            this.builder.Autoconnect(this)
            windownode.Maximize()
            windownode.ShowAll()

    [<EntryPoint>]
    let Main(args) =
        Application.Init()
        let mainwin = MainWindow(File "test.ui")
        Application.Run()
        0
