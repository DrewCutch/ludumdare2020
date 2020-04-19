using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public static class IsoUtils
{

    public static Plane plane;

    static IsoUtils()
    {
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    public static Vector3 ScreenToIso(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (plane.Raycast(ray, out var distance))
            return ray.GetPoint(distance);

        return Vector3.zero;
    }
}
