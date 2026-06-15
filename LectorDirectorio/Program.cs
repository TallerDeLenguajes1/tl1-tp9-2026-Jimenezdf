using System.IO;


Console.WriteLine("Ingrese un path de un directorio para analizar");
string path = Console.ReadLine();
if (!Directory.Exists(path))
{
    do


    {
            Console.WriteLine("Ingrese un path valido");
            path = Console.ReadLine();
    }while(!Directory.Exists(path));   
}
Console.WriteLine($"Directorio: {path}");
if (Directory.Exists(path))
{
    foreach(var file in Directory.GetDirectories(path).ToList())
    {
        Console.WriteLine($"Carpetas: {new DirectoryInfo(file).Name}");
    }
    
    List<ArchivoInfo> archivosInfo = new List<ArchivoInfo>();
    foreach(var file in Directory.GetFiles(path).ToList())
    {
        FileInfo info = new FileInfo(file);
        var _archivoInfo = new ArchivoInfo(info.Name, info.Length, info.LastWriteTime);
        archivosInfo.Add(_archivoInfo);
    }
    List<string> csvLines = new List<string>();
    foreach(var archivo in archivosInfo)
    {
        Console.WriteLine(archivo.ParaPantalla());
        csvLines.Add(archivo.ToCsv());
    }
    File.WriteAllLines(Path.Combine(path, "reporte_archivos.csv"), csvLines);
    
}


