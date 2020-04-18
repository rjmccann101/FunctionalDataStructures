// Workspace for experiments on data structures


type PartitionItem = {intVal:int; sum:int; subTree:PartitionItem list}


let root = {intVal=0 ; sum=0; subTree =[]}

let r1 = {root with subTree = [{intVal=3;sum=3;subTree=[]}]}
r1.subTree

let t1 = r1.subTree |> List.map(fun x -> {x with subTree = {intVal=2; sum=2+x.sum;subTree=[]} ::[]})

let r2= {root with subTree = ({intVal=2;sum=2;subTree=[]}::t1)}

