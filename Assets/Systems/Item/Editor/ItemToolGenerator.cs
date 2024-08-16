using UnityEditor;
using UnityEngine;

public class ItemToolGenerator
{
    private static string filePath = "Item/itemList";
    private static string outputFolder = "Item";

    [MenuItem("Tools/GenerateItems")]
    private static void GenerateItems()
    {
        TextAsset tsvData = Resources.Load<TextAsset>(filePath);

        if (tsvData != null)
        {
            string[] rows = tsvData.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split('\t');

                string itemName = columns[0];
                string itemDescription = columns[1];

                ItemInfo newItem = ScriptableObject.CreateInstance<ItemInfo>();
                newItem.itemName = itemName;
                newItem.itemDescription = itemDescription;

                string assetPath = outputFolder + "/" + itemName + ".asset";
                AssetDatabase.CreateAsset(newItem, assetPath);
                EditorUtility.SetDirty(newItem);
            }

            AssetDatabase.SaveAssets();
            Debug.Log("Assets Criados");
        }
        else
        {
            Debug.Log("Item Info not found");
        }
    }
}
