// See https://aka.ms/new-console-template for more information
/*
using SlocPorter;


CosturaUtility.Initialize();
Console.WriteLine("Loading SlocObject!");
bool recursive = true; //args.Length < 1;
try
{

    string curLoc = AppDomain.CurrentDomain.BaseDirectory;
    if (recursive)
    {
        foreach (string file in Directory.GetFiles(curLoc, "*.sloc"))
        {
            try
            {
                string name = Path.GetFileNameWithoutExtension(file);
                string outputLoc = Path.Combine(curLoc, "exports");
                if (!Directory.Exists(outputLoc))
                    Directory.CreateDirectory(outputLoc);
                Porter.PortFile(file, Path.Combine(outputLoc, name, name + ".json"));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Sloc Loading Error: {e}");
            }
        }
    }
}
catch (Exception e)
{
    Console.Error.WriteLine($"Main Program Error: {e}");
}
*/