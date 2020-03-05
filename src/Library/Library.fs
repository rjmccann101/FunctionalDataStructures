namespace Library

module List =
    let Halve a =
        match a with
        | [] -> ([],[])
        | hd::[] -> ([hd],[])
        | _ ->  let l = a.Length / 2
                (a.[..l-1], a.[l..])