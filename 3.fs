open System
open System.IO

let persWay persPath (letter: char) =
    Directory.EnumerateFiles(persPath)

    |> Seq.map Path.GetFileName
    |> Seq.filter (fun name -> 
        let ext = Path.GetExtension(name)
        ext.Length > 1 && ext.[1] = letter
    )
    

[<EntryPoint>]
let main argv =
    printfn "Введите путь к папке: "
    let persPath = Console.ReadLine()

    if Directory.Exists(persPath) then
        printfn "Введите букву для фильтра расширений"
        let oneLetter = Console.ReadLine()
    
        if not (String.IsNullOrWhiteSpace(oneLetter)) && 
            not(Char.IsDigit(oneLetter.[0])) then
            let target = oneLetter.[0]
            let filteredFiles = persWay persPath target  
            
            printfn "\nРезультаты поиска:" 
            if Seq.isEmpty filteredFiles then
                printfn "Файлов с таким расширенем нету."
            else
                filteredFiles |> Seq.iter (printfn "- %s")
        else
            printfn "Буква не введена или введена цифра."
    else 
        printfn "Путь не найден (nah)"

    0
