type person = { 
  name : string; 
  mutable age : int; 
}

let author = {name = "Jon"; age = 50}
let authorAlias = author
let authorCopy = {name = author.name; age = author.age}
let authorCopyAlt = {author with name = "Noj"}
author.age <- 51 (*//§\label{recordCopyAgeUpdate}§*)
printfn "author : %A" author
printfn "authorAlias : %A" authorAlias
printfn "authorCopy : %A" authorCopy
printfn "authorCopyAlt : %A" authorCopyAlt
