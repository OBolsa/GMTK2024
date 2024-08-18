using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour, IInteractable
{
    public GameObject totemPrefab;
    public PlayerInventorySO inventory;
    public List<BuffType> buffs = new List<BuffType>();
    public float placementOffset;
    private List<TotemAsset> totems = new List<TotemAsset>();

    public void Interact()
    {
        List<TotemItemInfo> parts = inventory.totemInventory;

        TotemItemInfo cocar = parts.Find(part => part.totemItemName == TotemItemType.Cocar.ToString());
        TotemItemInfo carranca = parts.Find(part => part.totemItemName == TotemItemType.Carranca.ToString());
        TotemItemInfo asa = parts.Find(part => part.totemItemName == TotemItemType.Asas.ToString());

        if (cocar != null && carranca != null && asa != null)
        {
            GameObject newTotem = Instantiate(totemPrefab);
            TotemAsset newTotemConfigs = newTotem.GetComponent<TotemAsset>();

            Vector3 nextPosition = transform.position + (Vector3.up * placementOffset * totems.Count);
            newTotem.transform.position = nextPosition;
            newTotem.transform.parent = transform;

            newTotemConfigs.SetupPart(TotemItemType.Cocar, cocar.totemItemBuffs);
            newTotemConfigs.SetupPart(TotemItemType.Carranca, carranca.totemItemBuffs);
            newTotemConfigs.SetupPart(TotemItemType.Asas, asa.totemItemBuffs);

            totems.Add(newTotemConfigs);
            buffs.AddRange(cocar.totemItemBuffs);
            buffs.AddRange(carranca.totemItemBuffs);
            buffs.AddRange(asa.totemItemBuffs);

            inventory.CleanTotemItemInfoList();
            LevelManager.Instance.PlaceTotem();



        }
        else
        {
            InstantMessageHandler.instance.ShowMessage("Don't have all 3 toten parts");
            Debug.Log("Não tem todas as partes");
        }
    }
}
