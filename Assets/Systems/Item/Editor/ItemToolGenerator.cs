using System.IO;
using UnityEditor;
using UnityEngine;

public class ItemToolGenerator
{
    private static string itemsPath = "Assets/Resources/Item"; // Certifique-se de que está dentro de 'Resources'
    private static string itemListPath = "Item/itemList"; // Dentro da pasta 'Resources/Item'

    [MenuItem("Tools/GenerateItems")]
    private static void GenerateItems()
    {
        TextAsset tsvData = Resources.Load<TextAsset>(itemListPath);

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
                newItem.name = itemName;

                // Cria o diretório se ele não existir
                if (!Directory.Exists(itemsPath))
                {
                    Directory.CreateDirectory(itemsPath);
                }

                // Use '/' como separador de diretório
                string assetPath = Path.Combine(itemsPath, $"{itemName}.asset").Replace("\\", "/");

                AssetDatabase.CreateAsset(newItem, assetPath);
                EditorUtility.SetDirty(newItem);
            }

            AssetDatabase.SaveAssets();
            Debug.Log("Assets Criados");
        }
        else
        {
            Debug.LogError("Item List not found");
        }
    }
}
