// See https://aka.ms/new-console-template for more information

using IronPdf;
using Toxy;
using Toxy.Parsers;

Console.WriteLine("Hello, World!");

//string[] filePaths = Directory.GetFiles("H:\\Source\\Appscience", " *.pdf", SearchOption.AllDirectories);
var filePaths = Directory.GetFiles("H:\\Source\\appscience", "*.pdf", SearchOption.AllDirectories);
string destFolder = "H:\\Source\\Appscience\\Декларации\\";
var counter = 0;
for (var index = 0; index < filePaths.Length; index++)
{
    Console.WriteLine($"{index} из {filePaths.Length}");
    var path = filePaths[index];
    var parser = new PDFTextParser(new ParserContext(path));
    string result = parser.Parse();
    if (!result.StartsWith("ДЕКЛАРАЦИЯ НА ТОВАРЫ", StringComparison.OrdinalIgnoreCase)) continue;

    var destPath = Path.Combine(destFolder, Path.GetFileNameWithoutExtension(path));
    if (File.Exists(destPath + ".pdf"))
        File.Copy(path, destPath + $"_{counter++}.pdf");
    else
        File.Copy(path, destPath + ".pdf");
}


Console.ReadLine();