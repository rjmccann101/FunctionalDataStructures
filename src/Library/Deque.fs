namespace FunctionalDataStructures

open System.Security.Cryptography

type Deque<'T> internal (front :'T List, back : 'T List) =
    member internal __.DQHeadList = front
    member internal __.DQTailList = back 

    member this.Head =
        match this.DQHeadList with
        | hd::_ -> Some hd
        | [] -> match this.DQTailList|> List.rev with
                | [] -> None 
                | hd::_ -> Some hd

    member this.Tail =
        match this.DQTailList with
        | hd::_ -> Some hd
        | [] -> match this.DQHeadList|> List.rev with
                | [] -> None 
                | hd::_ -> Some hd

    member this.PopHead =
        match this.DQHeadList with
            | hd::tl -> (Some hd, Deque(tl,this.DQTailList))
            | [] -> match this.DQTailList|> List.rev with
                    | [] -> (None , this)
                    | hd::tl -> (Some hd, Deque(tl,[]))

    member this.PopTail =
        match this.DQTailList with
        | hd::tl -> (Some hd, Deque(this.DQHeadList,tl))
        | [] -> match this.DQHeadList|> List.rev with
                | [] -> (None , this)
                | hd::tl -> (Some hd, Deque([],tl))

    member this.PushHead(v : 'T) =
        Deque(v::this.DQHeadList, this.DQTailList)

    member this.PushTail(v : 'T) =
        Deque(this.DQHeadList, v::this.DQTailList)

    member this.ToSeq =
        seq {
            for e in this.DQHeadList -> e
            for e in this.DQTailList |> List.rev -> e               
        }

    member this.ToRevSeq =
        seq {
            for e in this.DQTailList -> e
            for e in this.DQHeadList |> List.rev -> e               
        }



module Deque =
    let Create<'T> = Deque([],[])

