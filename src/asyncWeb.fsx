open System
open System.Net.Http
open Control.CommonExtensions   

// Create a single shared HttpClient instance
let httpClient = new HttpClient()

// Fetch the contents of a web page asynchronously using HttpClient
let fetchUrlAsync (url: string) =    
    async {
        let! response = httpClient.GetAsync(url) |> Async.AwaitTask
        let! html = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        printfn "finished downloading %s" url 
        return html
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
