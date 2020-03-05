module Library.Tests

open NUnit.Framework
open FsUnit
open Library

[<TestFixture>]
type ListHalveTestClass () =

 
    [<Test>]
    member this.SplitEmptyList() =
        let res = ([],[])
        Assert.AreEqual(res, (List.Halve []))

    [<Test>]
    member this.SplitList1() =
        let res = ([1],[])
        Assert.AreEqual(res,(List.Halve[1]))

    [<Test>]
    member this.SplitList2() =
        let res = ([1],[2])
        Assert.AreEqual(res,(List.Halve[1;2]))

    [<Test>]
    member this.SplitList3() =
        let res = ([1],[2;3])
        Assert.AreEqual(res,(List.Halve[1;2;3]))

    [<Test>]
     member this.SplitList4() =
         let res = ([1;2],[3;4])
         Assert.AreEqual(res,(List.Halve[1;2;3;4]))

