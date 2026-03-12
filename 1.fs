open System

let rec getlist() = 
    let s = Console.ReadLine()
    if String.IsNullOrWhiteSpace(s) then 
       []
    else 
        if Char.IsDigit(s.[0]) && s.Length = 1 then 
            let n = int s 
            n :: getlist()
        else
            printfn "Ошибка, букв или числ не должно быть" 
            getlist()

let toBin(n: int) = Convert.ToString(n, 2)

[<EntryPoint>]
let main argv = 
    printfn "Вводите числа:"
    

    let numbers = getlist()
    let afterToBin = numbers |> Seq.map toBin


    printfn "Числа %A" numbers
    printfn "Двоичная запись чисел %A" afterToBin

    0   