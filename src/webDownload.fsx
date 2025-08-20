open System
open System.Net.Http


// Create a single shared HttpClient instance
let httpClient = new HttpClient()

let fetchUrl (url: string) =        
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
sites                     // start with the list of sites
|> List.map fetchUrl      // loop through each site and download
printfn "%A msec" timer.ElapsedMilliseconds
