using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Flags]
public enum ResourceType
{
    None = 0,
    Grama = 1 << 0,
    Madeira = 1 << 1,
    Pedra = 1 << 2
}

[ExecuteAlways]
public class LevelDebugger : MonoBehaviour
{
    public ResourceType selectedResources = ResourceType.Grama | ResourceType.Madeira | ResourceType.Pedra;

    private List<SpawnDebugger> spawns = new List<SpawnDebugger>();
    private ResourceGroup groupGrama;
    private ResourceGroup groupMadeira;
    private ResourceGroup groupPedra;
    public float averageDistancePerSelection;

    public float AverageDistance
    {
        get
        {
            float totalDistance = 0f;
            int count = 0;

            foreach (var spawnDebugger in spawns)
            {
                ResourceType resourceType = GetResourceType(spawnDebugger.spawnGroup);

                // Se o tipo de recurso estiver selecionado
                if ((selectedResources & resourceType) != 0)
                {
                    foreach (var spawnArea in spawnDebugger.spawnAreas)
                    {
                        totalDistance += Vector3.Distance(transform.position, spawnArea.transform.position);
                        count++;
                    }
                }
            }

            return count > 0 ? totalDistance / count : 0f;
        }
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        SetupSpawns();
    }
    private void OnDisable()
    {
        ClearSpawns();
    }
    private void Update()
    {
        averageDistancePerSelection = AverageDistance;
    }
    private void OnDrawGizmos()
    {
        foreach (var spawnDebugger in spawns)
        {
            ResourceType resourceType = GetResourceType(spawnDebugger.spawnGroup);

            // Verifica se o tipo de recurso está selecionado no enum
            if ((selectedResources & resourceType) != 0)
            {
                Color color = GetGroupColor(spawnDebugger.spawnGroup);

                foreach (var spawnArea in spawnDebugger.spawnAreas)
                {
                    Vector3 managerPos = transform.position;
                    Vector3 areaPos = spawnArea.transform.position;

                    Gizmos.color = color;
                    Gizmos.DrawLine(managerPos, areaPos);
                }
            }
        }
    }
#endif

    [ContextMenu("SetupSpawns")]
    private void SetupSpawns()
    {
        groupGrama = Resources.Load<ResourceGroup>("Resources Groups/Grama");
        groupMadeira = Resources.Load<ResourceGroup>("Resources Groups/Madeira");
        groupPedra = Resources.Load<ResourceGroup>("Resources Groups/Pedra");

        List<SpawnArea> areas = FindObjectsOfType<SpawnArea>(true).ToList();

        List<SpawnArea> areasForGrama = areas.FindAll(a => groupGrama.items.Contains(a.spawnItem));
        List<SpawnArea> areasForMadeira = areas.FindAll(a => groupMadeira.items.Contains(a.spawnItem));
        List<SpawnArea> areasForPedra = areas.FindAll(a => groupPedra.items.Contains(a.spawnItem));

        spawns.Add(new SpawnDebugger(groupGrama, areasForGrama));
        spawns.Add(new SpawnDebugger(groupMadeira, areasForMadeira));
        spawns.Add(new SpawnDebugger(groupPedra, areasForPedra));
    }

    [ContextMenu("ClearSpawns")]
    private void ClearSpawns()
    {
        spawns.Clear();
    }


    private ResourceType GetResourceType(ResourceGroup group)
    {
        if (group == groupGrama)
            return ResourceType.Grama;
        if (group == groupMadeira)
            return ResourceType.Madeira;
        if (group == groupPedra)
            return ResourceType.Pedra;

        return ResourceType.None;
    }

    private Color GetGroupColor(ResourceGroup group) => group.baseColor;
}

[System.Serializable]
public class SpawnDebugger
{
    public ResourceGroup spawnGroup;
    public List<SpawnArea> spawnAreas;

    public SpawnDebugger(ResourceGroup spawnGroup, List<SpawnArea> spawnAreas)
    {
        this.spawnGroup = spawnGroup;
        this.spawnAreas = spawnAreas;
    }
}
