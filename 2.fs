open System

let rec getSeq() = seq {
    let s = Console.ReadLine()
    if not (String.IsNullOrWhiteSpace(s)) then
        if s.Length = 1 && Char.IsDigit(s.[0]) then
            yield int s            // Выдаем число в поток
            yield! getSeq()        // Рекурсивно продолжаем поток
        else
            printfn "Ошибка!"
            yield! getSeq()        // Пропускаем ошибку и продолжаем поток
}

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
    printfn "Вводите цифры (Enter для завершения):"
    
    let mySeq = getSeq()

    let resultString = 
        mySeq 
        |> Seq.fold (fun all n -> all + " " + rusWords n) ""
        
    printfn "Ваша последовательность: %A" (Seq.toList mySeq)
    printfn "Результат через fold: %s" (resultString.Trim())

    0
