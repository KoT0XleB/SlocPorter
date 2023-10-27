// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         SerializableSchematicObjectDataList.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/24/2023 3:16 PM
//    Created Date:     10/24/2023 3:16 PM
// -----------------------------------------

using MapEditorReborn.API.Enums;
using UnityEngine;

namespace SlocPorter;

public class SerializableSchematicBlockData
{
    public virtual string Name { get; set; } = "";

    public virtual int ObjectId { get; set; }

    public virtual int ParentId { get; set; }

    public virtual string AnimatorName { get; set; } = "";

    public virtual SerializableVector3 Position { get; set; }

    public virtual SerializableVector3 Rotation { get; set; }

    public virtual SerializableVector3 Scale { get; set; }

    public virtual BlockType BlockType { get; set; }

    public virtual Dictionary<string, object> Properties { get; set; }
}