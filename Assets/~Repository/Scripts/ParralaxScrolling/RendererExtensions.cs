using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer _renderer, Camera _camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        return GeometryUtility.TestPlanesAABB(planes, _renderer.bounds);
    }
}
