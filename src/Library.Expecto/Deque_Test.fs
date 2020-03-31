module Deque_Test

open Expecto
open Expecto.ExpectoFsCheck
open FsCheck
open FunctionalDataStructures


let config = { FsCheck.Config.Default with MaxTest = 1000 }

let properties =
    testList "Deque Tests" [
        testProperty "PushHead is head" <| fun (q : Deque<int> ) (v : int) -> 
            (q.PushHead v).Head = Some v
    ]

Tests.runTests defaultConfig properties |> ignore<int>