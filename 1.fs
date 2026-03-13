open System

let rec getSeq() = seq {
    let s = Console.ReadLine()
    if not (String.IsNullOrWhiteSpace(s)) then 
        if Char.IsDigit(s.[0]) && s.Length = 1 then 
            yield int s          // "Выдаем" одно число
            yield! getSeq()      // Рекурсивно "подмешиваем" остальную последовательность
        else
            printfn "Ошибка, введите одну цифру" 
            yield! getSeq()      
}

let toBin(n: int) = Convert.ToString(n, 2)

[<EntryPoint>]
let main args = 
    printfn "Вводите цифры (пустая строка для выхода):"

    let numbers = getSeq() |> Seq.toList 
    let afterToBin = numbers |> Seq.map toBin

    printfn "Числа: %A" numbers
    printfn "Двоичная запись: %A" afterToBin

    0
