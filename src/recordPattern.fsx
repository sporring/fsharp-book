type Address = {street : string; zip : int; country : string}
let contact : Address = {
    street = "Universitetsparken 1"; 
    zip = 2100; 
    country = "Denmark"}
let getZip (adr : Address) : int =
  match adr with
    {street = _; zip = z; country = _} -> z

printfn "The zip-code is: %d" (getZip contact)