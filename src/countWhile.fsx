let mutable i = 1 (*//§\label{countWhileLoop}§*)
while i <= 10 do (*//§\label{countWhileLoopTest}§*)
  printf "%d " i(*//§\label{countWhileLoopBody}§*)
  i <- i + 1
printf "\n"(*//§\label{countWhileContinue}§*)
