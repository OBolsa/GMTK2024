#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ResourcesTypeTools
{
    public static string generalPath = "ResourcesTypes";

#if UNITY_EDITOR
    [MenuItem("Tools/Level/Rename Resources Type Files")]
    private static void RenameFiles()
    {
        ResourceGroup[] files = Resources.LoadAll<ResourceGroup>(generalPath);

        if (files.Length > 0)
        {
            foreach (ResourceGroup item in files)
            {
                string path = generalPath + "/" + item.name + ".asset";

                AssetDatabase.RenameAsset(path, item.type);
            }

            AssetDatabase.SaveAssets();
        }
        else
        {
            Debug.Log("No Items Founded");
        }

    }
#endif

}
