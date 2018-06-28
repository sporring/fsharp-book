open System
open System.Net
open Control.CommonExtensions   

// Fetch the contents of a web page asynchronously
let fetchUrlAsync url =        
    async {                             
        let req = WebRequest.Create(Uri(url)) 
        use! resp = req.AsyncGetResponse()  // new keyword "use!"  
        use stream = resp.GetResponseStream() 
        use reader = new IO.StreamReader(stream) 
        let html = reader.ReadToEnd() 
        printfn "finished downloading %s" url 
        }

// a list of sites to fetch
let sites = ["http://www.bing.com";
             "http://www.google.com";
             "http://www.microsoft.com";
             "http://www.amazon.com";
             "http://www.yahoo.com"]

let timer = new Diagnostics.Stopwatch()
timer.Start()
sites 
|> List.map fetchUrlAsync  // make a list of async tasks
|> Async.Parallel          // set up the tasks to run in parallel
|> Async.RunSynchronously  // start them off
printfn "%A msec" timer.ElapsedMilliseconds
