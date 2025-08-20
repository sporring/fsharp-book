let a = seq {for i in 0..10 do if i%2=0 then yield i}
for i in a do printf "%d " i; done; printfn ""
