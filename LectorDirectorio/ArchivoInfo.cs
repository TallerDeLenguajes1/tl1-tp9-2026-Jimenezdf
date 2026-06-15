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