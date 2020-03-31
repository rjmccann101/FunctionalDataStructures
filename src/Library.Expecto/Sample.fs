module Tests

open Expecto
open Expecto.ExpectoFsCheck
open FsCheck
open FunctionalDataStructures


type DequeGen() =
    static member Deque() : Arbitrary<Deque<int>> =
        let CreateDeque ele =
            Deque.FromList ele
        let getEle = Gen.listOf(Gen.choose(0,10))
        let genDeque =
            CreateDeque <!> getEle
        genDeque |> Arb.fromGen

let config = {FsCheckConfig.defaultConfig with arbitrary = [typeof<DequeGen>]}

[<Tests>]
let tests =
  testList "samples" [
 
    testProperty "Reverse of reverse of a list is the original list" <|
    fun (xs:list<int>) -> List.rev (List.rev xs) = xs

    let PopHeadAll (q :Deque<int>) : List<int> =
        let rec loop acc (q :Deque<int>) =
            match q.PopHead with
            | (Some x, q') -> loop (x::acc) q'
            | _ -> acc
        loop [] q |> List.rev

    testProperty "Take head gives list" <|
    fun (xs:list<int>) -> Deque.FromList xs |> PopHeadAll = xs

    let PopTailAll (q :Deque<int>) : List<int> =
        let rec loop acc (q :Deque<int>) =
            match q.PopTail with
            | (Some x, q') -> loop (x::acc) q'
            | _ -> acc
        loop [] q |> List.rev

    testProperty "Take tail gives reversed list" <|
    fun (xs:list<int>) -> Deque.FromList xs |> PopTailAll = (xs |> List.rev)

    testPropertyWithConfig config "PushHead is head" <| fun (q : Deque<int> ) (v : int) -> 
        (q.PushHead v).Head = Some v

    testPropertyWithConfig config "PushTail is head" <| fun (q : Deque<int> ) (v : int) -> 
        (q.PushTail v).Tail = Some v

  ]
