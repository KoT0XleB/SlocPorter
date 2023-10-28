// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         Command.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/24/2023 2:54 PM
//    Created Date:     10/24/2023 2:54 PM
// -----------------------------------------

using CommandSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace SlocPorter;
[CommandHandler(typeof(GameConsoleCommandHandler))]
[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class PortCommand : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        string portFolder = Path.Combine(PluginAPI.Helpers.Paths.GlobalPlugins.Plugins, "SlocPorter");

        int count = 0;
        try
        {
            string curLoc = Path.Combine(portFolder, "Import");

            foreach (string file in Directory.GetFiles(curLoc, "*.sloc"))
            {
                try
                {
                    string name = Path.GetFileNameWithoutExtension(file);
                    string outputLoc = Path.Combine(portFolder, "Export");
                    if (!Directory.Exists(outputLoc))
                        Directory.CreateDirectory(outputLoc);
                    Porter.PortFile(file, Path.Combine(outputLoc, name, name + ".json"));
                }
                catch (Exception e)
                {
                    Log.Error($"Sloc Loading Error: {e}");
                }
                count++;
            }
        }
        catch (Exception e)
        {
            response = ($"Main Program Error: {e}");
            return false;
        }

        response = $"Ported {count} files to => global/SlocPorter/Export";
        return true;
    }

    public string Command => "SlocPort";
    public string[] Aliases => new[] { "" };
    public string Description => "Ports sloc files in a folder to MER Schematic json files.";
}