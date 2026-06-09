using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;




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
        Console.WriteLine($"Carpetas: {file}");
    }
    
    List<ArchivoInfo> archivosInfo = new List<ArchivoInfo>;
    foreach(var file in Directory.GetFiles(path).ToList())
    {
        Console.WriteLine($"Archivos: {file}");
        FileInfo info = new FileInfo(file);
        Console.WriteLine($"Archivo: {info.Name})"+ "-" + ($"Tamaño: {info.Length} bytes"));
        var _archivoInfo = new ArchivoInfo(info.Name, info.Length, info.LastWriteTime);
        archivosInfo.Add(_archivoInfo);
        System.Console.WriteLine(_archivoInfo.ToCsv());
    }
    List<string> csvLines = new List<string>;
    foreach(var archivos in archivosInfo)
    {
        Console.WriteLine(archivo.ParaPantalla());
        csvLines.Add(archivo.ToCsv());
    }
    File.WriteAllLines("Reporte_archivos.csv", csvLines);
    
}

public class ArchivoInfo
{    
public string Nombre (get; set;)
public long Tamanio (get; set;)
public DateTime UltimaFechaDeModificacion (get; set;)
public ArchivoInfo(string name, long length, DateTime LastWriteTime)
    {
        Nombre = name;
        Tamanio = length;
        UltimaFechaDeModificacion = LastWriteTime;
    }
public string ToCsv()
    {
        return $("")
    }
public string ParaPantalla()
    {
        
    }
}



    /*string[] archivos = Directory.GetFiles(path);
    string [] carpetas = Directory.GetDirectories(path);

    Console.WriteLine($"Archivos en el directorio:{archivos.Length}");
    Console.WriteLine($"carpetas en el directorio: {carpetas.Length}");

    foreach(string a in archivos) Console.WriteLine($"  {a}");
    foreach(string c in carpetas) Console.WriteLine($"  {c}");*/