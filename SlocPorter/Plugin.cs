// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         Plugin.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/24/2023 2:53 PM
//    Created Date:     10/24/2023 2:53 PM
// -----------------------------------------

using PluginAPI.Core;
using PluginAPI.Core.Attributes;

namespace SlocPorter;

public class Plugin
{
    public Plugin Singleton { get; private set; }
    [PluginEntryPoint("SlocPorter", "1.0.0", "A porter for Sloc -> MER", "Redforce04")]
    public void OnStart()
    {
        Log.Debug("Loaded Sloc Porter");
        Singleton = this;
    }

    [PluginUnload]
    public void OnStop()
    {
        Singleton = null;
    }
    
}