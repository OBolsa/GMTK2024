using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour, IInteractable
{
    public GameObject totemPrefab;
    public PlayerInventorySO inventory;
    public List<BuffType> buffs = new List<BuffType>();
    public float placementOffset;
    private List<TotemAsset> totems = new List<TotemAsset>();
    [SerializeField]
    private float wobbleInterval;

    private void Start()
    {
        LevelManager.Instance.attributes.UpdateBuffs(buffs);
    }

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

            LevelManager.Instance.buffs = new List<BuffType>(buffs);
            LevelManager.Instance.attributes.UpdateBuffs(buffs);
            LevelManager.Instance.PlaceTotem();

            StartCoroutine(WobbleColumn());
        }
        else
        {
            InstantMessageHandler.instance.ShowMessage("Don't have all 3 totem parts");
            Debug.Log("N�o tem todas as partes");
        }
    }

    public IEnumerator WobbleColumn()
    {
        yield return new WaitForSeconds(1);

        foreach (var item in totems)
        {
            item.Wobble();
            yield return new WaitForSeconds(wobbleInterval);
        }
    }
}
