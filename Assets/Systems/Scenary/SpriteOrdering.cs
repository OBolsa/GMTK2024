using UnityEngine;

public class SpriteOrdering : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool liveUpdate;

    private void Start()
    {
        UpdateOrder();
    }

    private void Update()
    {
        if (liveUpdate)
        {
            UpdateOrder();
        }
    }

    private void UpdateOrder()
    {
        int order = (int)transform.position.y * -1;
        sr.sortingOrder = order;
    }
}
