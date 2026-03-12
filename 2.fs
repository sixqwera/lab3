open System

let rec getList() = 
    let s = Console.ReadLine()
    if String.IsNullOrWhiteSpace(s) then
        []
    else
        if s.Length = 1 && Char.IsDigit(s.[0]) then
            let n = int s 
            n :: getList()
        else
            printfn "Ошибка!"
            getList() 

let rusWords n = 
    match n with

    | 0 -> "ноль" 
    | 1 -> "один" 
    | 2 -> "два" 

    | 3 -> "три"   
    | 4 -> "четыре" 
    | 5 -> "пять" 

    | 6 -> "шесть" 
    | 7 -> "семь" 
    | 8 -> "восемь" 

    | 9 -> "девять"
    | _ -> "???"

[<EntryPoint>]
let main argv = 
    printfn "Вводите цифры:"
    let myList = getList()

    let resultString = 
        myList 
        |> Seq.fold (fun all n -> all + " " + rusWords n) ""

    printfn "Ваш список: %A" myList
    printfn "Результат через fold: %s" (resultString.Trim())

    0