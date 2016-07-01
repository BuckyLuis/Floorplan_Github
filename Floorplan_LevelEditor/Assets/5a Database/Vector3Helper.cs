using UnityEngine;
using System.Collections;

public static class Vector3Helper
{
    public static Vector3 FromString(this Vector3 vector, string value){
        string[] temp = value.Replace(" ", "").Split(',');
        vector.x = float.Parse(temp[0]);
        vector.y = float.Parse(temp[1]);
        vector.z = float.Parse(temp[2]);

        return vector;
    }
}