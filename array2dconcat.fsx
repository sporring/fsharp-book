let Array2Dconcat (a1: 'T [,]) (a2: 'T [,]) =
    let a1l1,a1l2,a2l1,a2l2 = (Array2D.length1 a1),(Array2D.length2 a1),(Array2D.length1 a2),(Array2D.length2 a2)
    if a1l2 <> a2l2 then failwith "arrays have different column sizes"
    let result = Array2D.zeroCreate (a1l1 + a2l1) a1l2
    Array2D.blit a1 0 0 result 0 0 a1l1 a1l2
    Array2D.blit a2 0 0 result a1l1 0 a2l1 a2l2
    result
