using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Resource Type Manager")]
public class ResourceTypeManager : ScriptableObject
{
    public List<ResourceGroup> types = new List<ResourceGroup>();
}