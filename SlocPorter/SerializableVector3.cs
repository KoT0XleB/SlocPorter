// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         SlocPorter
//    Project:          SlocPorter
//    FileName:         Vector3Serializer.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/24/2023 3:15 PM
//    Created Date:     10/24/2023 3:15 PM
// -----------------------------------------


using UnityEngine;

namespace SlocPorter;

public class SerializableVector3
{
    public SerializableVector3()
    {
    }

    public SerializableVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public float x { get; set; }

    public float y { get; set; }

    public float z { get; set; }

    public static implicit operator SerializableVector3(Vector3 vector) => new SerializableVector3(vector.x, vector.y, vector.z);

    public static implicit operator Vector3(SerializableVector3 vector) => new Vector3(vector.x, vector.y, vector.z);
}