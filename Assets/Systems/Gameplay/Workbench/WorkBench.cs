using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkBench : MonoBehaviour, IInteractable
{
    public PlayerInventorySO inventory;
    public ResourceGroup resourceOne;
    public ResourceGroup resourceTwo;
    public TotemItemType type;
    public bool canInteract;

    private SpriteRenderer renderer;
    private Color startColor;


    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.color;
    }

    public void Interact()
    {
        if (!canInteract)
            return;

        bool haveResourceOne = inventory.HaveAnyItemsOfItemGroup(resourceOne);
        bool haveResourceTwo = inventory.HaveAnyItemsOfItemGroup(resourceTwo);

        if (haveResourceOne && haveResourceTwo)
        {
            ItemInfo itemOne = inventory.FindFirstMatchingItem(inventory.itemInventory, resourceOne.items);
            ItemInfo itemTwo = inventory.FindFirstMatchingItem(inventory.itemInventory, resourceTwo.items);

            List<BuffType> buffs = GetBuffs(itemOne, itemTwo);

            TotemItemInfo totemItem = new TotemItemInfo(type.ToString(), buffs, null);

            inventory.RemoveItemFromInventory(itemOne);
            inventory.RemoveItemFromInventory(itemTwo);
            inventory.totemInventory.Add(totemItem);

            canInteract = false;
            renderer.color = Color.black;
            LevelManager.Instance.TotemPartDone?.Invoke(totemItem);
            particles.Play();
            AudioManager.instance.PlaySfx(SFXs.SMASH_BUMP);

        }
        else
        {
            InstantMessageHandler.instance.ShowMessage("You still miss some materials!!");
            Debug.Log("Faltam itens!");
        }
    }

    public void RestartBench()
    {
        canInteract = true;
        renderer.color = startColor;
    }

    private List<BuffType> GetBuffs(ItemInfo itemOne, ItemInfo itemTwo)
    {
        List<BuffType> result = new List<BuffType>(itemOne.itemBuffs);

        foreach (var buff in itemTwo.itemBuffs)
        {
            result.Add(buff);
        }

        return result;
    }
}

public enum TotemItemType { None, Carranca, Cocar, Asas }