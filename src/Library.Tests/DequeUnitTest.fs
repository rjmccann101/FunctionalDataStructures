module Deque.Tests

open NUnit.Framework
open FsUnit
open FunctionalDataStructures

[<TestFixture>]
type DequeTestClass () =

 
    [<Test>]
    member this.PopHeadTest() =
        let dq = Deque.Create<int>.PushHead(2).PushHead(1).PushTail(3).PushTail(4)
        Assert.IsFalse(dq.IsEmpty)
        let (v1,dq1) = dq.PopHead
        Assert.AreEqual(1, v1.Value)
        let (v2,dq2) = dq1.PopHead
        Assert.AreEqual(2, v2.Value)
        let (v3,dq3) = dq2.PopHead
        Assert.AreEqual(3, v3.Value)
        let (v4,dq4) = dq3.PopHead
        Assert.AreEqual(4, v4.Value)
        Assert.IsTrue(dq4.IsEmpty)

    [<Test>]
    member this.PopTailTest() =
        let dq = Deque.Create<int>.PushHead(2).PushHead(1).PushTail(3).PushTail(4)
        Assert.IsFalse(dq.IsEmpty)
        let (v1,dq1) = dq.PopTail
        Assert.AreEqual(4, v1.Value)
        let (v2,dq2) = dq1.PopTail
        Assert.AreEqual(3, v2.Value)
        let (v3,dq3) = dq2.PopTail
        Assert.AreEqual(2, v3.Value)
        let (v4,dq4) = dq3.PopTail
        Assert.AreEqual(1, v4.Value)
        Assert.IsTrue(dq4.IsEmpty)

    [<Test>]
    member this.FromListTest1() =
        let dq = Deque.FromList [1;2;3;4]
        Assert.IsFalse(dq.IsEmpty)
        let (v1,dq1) = dq.PopHead
        Assert.AreEqual(1, v1.Value)
        let (v2,dq2) = dq1.PopTail
        Assert.AreEqual(4, v2.Value)
        let (v3,dq3) = dq2.PopHead
        Assert.AreEqual(2, v3.Value)
        let (v4,dq4) = dq3.PopTail
        Assert.AreEqual(3, v4.Value)
        Assert.IsTrue(dq4.IsEmpty)