using System.IO;
using System.Text;

Console.WriteLine("Ingrese la ruta completa del archivo MP3:");
string path = Console.ReadLine();

if (!File.Exists(path))
{
    Console.WriteLine("El archivo no existe.");
    return;
}

FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

if (fs.Length < 128)
{
    Console.WriteLine("El archivo es demasiado pequeño para contener un Tag ID3v1.");
    fs.Close(); 
    return;
}

fs.Seek(-128, SeekOrigin.End);

byte[] tagBytes = new byte[128];
fs.Read(tagBytes, 0, 128);

fs.Close();

Encoding encoding = Encoding.GetEncoding("latin1");

string header = encoding.GetString(tagBytes, 0, 3);

if (header == "TAG")
{
    Id3v1Tag miTag = new Id3v1Tag
    {
        Titulo = encoding.GetString(tagBytes, 3, 30).Trim('\0', ' '),
        Artista = encoding.GetString(tagBytes, 33, 30).Trim('\0', ' '),
        Album = encoding.GetString(tagBytes, 63, 30).Trim('\0', ' '),
        Anio = encoding.GetString(tagBytes, 93, 4).Trim('\0', ' ')
    };

    Console.WriteLine("\n--- Tag Encontrado ---");
    Console.WriteLine($"Título:  {miTag.Titulo}");
    Console.WriteLine($"Artista: {miTag.Artista}");
    Console.WriteLine($"Álbum:   {miTag.Album}");
    Console.WriteLine($"Año:     {miTag.Anio}");
}
else
{
    Console.WriteLine("El archivo no contiene un tag ID3v1 válido (falta la palabra 'TAG').");
}
