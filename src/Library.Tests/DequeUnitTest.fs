module Deque.Tests

open NUnit.Framework
open FsUnit
open FunctionalDataStructures

[<TestFixture>]
type DequeTestClass () =

 
    [<Test>]
    member this.PopHeadTest() =
        let dq = Deque.Create<int>.PushHead(2).PushHead(1).PushTail(3).PushTail(4)
        let (v1,dq1) = dq.PopHead
        Assert.AreEqual(1, v1.Value)
        let (v2,dq2) = dq1.PopHead
        Assert.AreEqual(2, v2.Value)
        let (v3,dq3) = dq2.PopHead
        Assert.AreEqual(3, v3.Value)
        let (v4,_) = dq3.PopHead
        Assert.AreEqual(4, v4.Value)