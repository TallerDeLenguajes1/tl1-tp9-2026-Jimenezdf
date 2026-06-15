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

public class ArchivoInfo
{    
public string Nombre {get; set;}
public double Tamanio {get; set;}
public DateTime UltimaFechaDeModificacion {get; set;}
public ArchivoInfo(string name, long length, DateTime LastWriteTime)
    {
        Nombre = name;
        Tamanio = length / 1024.0;
        UltimaFechaDeModificacion = LastWriteTime;
    }
public string ToCsv()
    {
        return $"{Nombre},{Tamanio:0.00},{UltimaFechaDeModificacion}";
    }
public string ParaPantalla()
    {
        return $"Archivo: {Nombre} - Tamaño: {Tamanio:0.00} KB";
    }
}



    /*string[] archivos = Directory.GetFiles(path);
    string [] carpetas = Directory.GetDirectories(path);

    Console.WriteLine($"Archivos en el directorio:{archivos.Length}");
    Console.WriteLine($"carpetas en el directorio: {carpetas.Length}");

    foreach(string a in archivos) Console.WriteLine($"  {a}");
    foreach(string c in carpetas) Console.WriteLine($"  {c}");*/