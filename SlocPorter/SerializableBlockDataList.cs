// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         SerializableBlockDataList.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/24/2023 3:18 PM
//    Created Date:     10/24/2023 3:18 PM
// -----------------------------------------

namespace SlocPorter;

[Serializable]
public class SerializableBlockDataList
{

    public int RootObjectId { get; set; }

    public List<SerializableSchematicBlockData> Blocks { get; set; } = new List<SerializableSchematicBlockData>();
}