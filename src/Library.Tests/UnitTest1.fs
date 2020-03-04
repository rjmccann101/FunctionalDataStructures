module Library.Tests

open NUnit.Framework
open FsUnit
open Library

[<TestFixture>]
type TestClass () =

 
    [<Test>]
    member this.SplitEmptyList() =
        let res = ([],[])
        Assert.AreEqual((List.Halve []), res)

    [<Test>]
    member this.SplitSingleList() =
        let res = ([1],[])
        Assert.AreEqual((List.Halve[1]),res)
