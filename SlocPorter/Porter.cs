// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         Porter.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/23/2023 10:04 PM
//    Created Date:     10/23/2023 10:04 PM
// -----------------------------------------

using System.ComponentModel;
using System.Text;
using MapEditorReborn.API.Enums;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Serializable;
using Newtonsoft.Json;
using PluginAPI.Core;
using slocLoader.Objects;
using UnityEngine;
using ObjectType = slocLoader.Objects.ObjectType;

namespace SlocPorter;

public class Porter
{
    public static void PortFile(string fileName, string outputFile)
    {
        var objectList = slocLoader.API.ReadObjects(File.Open(fileName, FileMode.Open));
        // MapEditorReborn.API.Features.ObjectSpawner.SpawnSchematic();
        // return ObjectSpawner.SpawnSchematic(, new Vector3?(position), rotation, scale, data);
        var serializable = new SerializableBlockDataList();
        int parentId = 0;
        
        foreach (var obj in objectList)
        {
            if (parentId == 0)
            {
                parentId = obj.ParentId;
            }

            if (parentId == obj.InstanceId)
            {
                parentId = obj.ParentId;
            }
            if (obj.Type is ObjectType.None or ObjectType.Empty)
            {
                continue;
            }

            var blockData = new SerializableSchematicBlockData();
            if (blockData.Properties is null)
            {
                blockData.Properties = new Dictionary<string, object>();
            }
            blockData.Position = obj.Transform.Position;
            blockData.Rotation = obj.Transform.Rotation.eulerAngles;
            blockData.Scale = obj.Transform.Scale;
            blockData.ObjectId = obj.InstanceId;
            blockData.ParentId = obj.ParentId;

            if (obj.Type is ObjectType.Light)
            {
                if (obj is not LightObject lightObject)
                    continue; 
                /*
                * this.Color = block.Properties["Color"].ToString();
                * this.Intensity = float.Parse(block.Properties["Intensity"].ToString());
                * this.Range = float.Parse(block.Properties["Range"].ToString());
                *  this.Shadows = bool.Parse(block.Properties["Shadows"].ToString());
                */
                SerializableColor color = lightObject.LightColor;
                blockData.BlockType = BlockType.Light; 
                blockData.Properties.Add("Color",  color.ToString());
                blockData.Properties.Add("Intensity", lightObject.Intensity);
                blockData.Properties.Add("Range", lightObject.Range);
                blockData.Properties.Add("Shadows", lightObject.Shadows);
                serializable.Blocks.Add(blockData);
                continue;
            }
            // this.PrimitiveType = (PrimitiveType)Enum.Parse(typeof(PrimitiveType), block.Properties["PrimitiveType"].ToString());
			// this.Color = block.Properties["Color"].ToString();
            blockData.BlockType = BlockType.Primitive;
            try
            {
                blockData.Properties.Add("PrimitiveType", GetBlockType(obj.Type));
            }
            catch (InvalidEnumArgumentException)
            {
                Log.Debug("Unsupported Block Type.");
                continue;
            }

            if (obj is not PrimitiveObject primitiveObject)
            {
                continue;
            }
            SerializableColor matColor = primitiveObject.MaterialColor;

            blockData.Properties.Add("Color", matColor.ToString());
            
            // blockData  new MapEditorReborn.API.Features.Serializable.PrimitiveSerializable();
            
            serializable.Blocks.Add(blockData);
        }

        serializable.RootObjectId = parentId;
        string outputData = JsonConvert.SerializeObject(serializable, Formatting.Indented);
       //serializable.RootObjectId = objectList.
        string outputFileDirectory = outputFile.Replace(Path.GetFileName(outputFile), "");
        if (!Directory.Exists(outputFileDirectory))
            Directory.CreateDirectory(outputFileDirectory);
        if (File.Exists(outputFile))
        {
            File.Delete(outputFile);
        }
        var stream = File.Open(outputFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
        byte[] info = new UTF8Encoding(true).GetBytes(outputData);
        stream.Write(info, 0, info.Length);
        stream.Close();
    }
    public static PrimitiveType GetBlockType(slocLoader.Objects.ObjectType obj) => obj switch
    {
        ObjectType.Capsule => PrimitiveType.Capsule,
        ObjectType.Cube => PrimitiveType.Cube,
        ObjectType.Cylinder => PrimitiveType.Cylinder,
        ObjectType.Plane => PrimitiveType.Plane,
        ObjectType.Quad => PrimitiveType.Quad,
        ObjectType.Sphere => PrimitiveType.Sphere,
        ObjectType.Light or ObjectType.None or ObjectType.Empty or _ => throw new InvalidEnumArgumentException()
    };
}

public enum PrimitiveType
{
    Capsule,
    Cube,
    Cylinder,
    Plane,
    Quad,
    Sphere,
}