open System.Net.Http

let result =
    async {
        let client = new HttpClient ()
        let url = "https://api.frankfurter.app/latest?amount=10.99&from=USD&to=PLN"

        let! result =
            client.GetStreamAsync url
            |> Async.AwaitTask

        printfn "%A" result
    }

result |> Async.RunSynchronously
