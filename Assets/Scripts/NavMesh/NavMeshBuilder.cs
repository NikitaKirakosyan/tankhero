/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public sealed class NavMeshBuilder : MonoBehaviour
{
    public List<NavMeshSurface> Surfaces { get; private set; } = new List<NavMeshSurface>(2);

    private void Awake()
    {
        if (Surfaces == null || Surfaces.Count == 0)
        {
            Surfaces = FindObjectsOfType<NavMeshSurface>().ToList();
        }

        BakeNavMesh();
    }

    public void BakeNavMesh()
    {
        Surfaces.ForEach(surface => surface.BuildNavMesh());
    }

    public void UpdateNavMesh()
    {
        Surfaces.ForEach(surface => surface.UpdateNavMesh(surface.navMeshData));
    }
}