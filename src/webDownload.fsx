open System
open System.Net

let fetchUrl url =        
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    let html = reader.ReadToEnd() 
    printfn "finished downloading %s" url

// a list of sites to fetch
let sites = ["http://www.bing.com";
             "http://www.google.com";
             "http://www.microsoft.com";
             "http://www.amazon.com";
             "http://www.yahoo.com"]

let timer = new Diagnostics.Stopwatch()
timer.Start()
sites                     // start with the list of sites
|> List.map fetchUrl      // loop through each site and download
printfn "%A msec" timer.ElapsedMilliseconds
