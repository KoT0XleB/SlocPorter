// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         SerializableColor.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/24/2023 3:27 PM
//    Created Date:     10/24/2023 3:27 PM
// -----------------------------------------

using Newtonsoft.Json;
using UnityEngine;

namespace SlocPorter;

public class SerializableColor
{
    public SerializableColor(byte r, byte g, byte b, byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public SerializableColor(float r, float g, float b, float a)
    {
        R = (byte) (r * 255f);
        G = (byte) (g * 255f);
        B = (byte) (b * 255f);
        A = (byte) (a * 255f);
        
    }
    [JsonIgnore]
    public byte R { get; set; }
    [JsonIgnore]
    public byte G { get; set; }
    [JsonIgnore]
    public byte B { get; set; }
    [JsonIgnore]
    public byte A { get; set; }

    public override string ToString()
    {
        return $"{R:X2}{G:X2}{B:X2}{A:X2}";
    }

    public static implicit operator SerializableColor(Color color) => new SerializableColor(color.r, color.g, color.b, color.a);
}