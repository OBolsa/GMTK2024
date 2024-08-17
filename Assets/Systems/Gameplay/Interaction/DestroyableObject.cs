using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DestroyableObject : MonoBehaviour, IInteractable
{
    private Image lifeGauge;

    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    public UnityEvent OnDestroy;

    private void Start()
    {
        currentHealth = maxHealth;
        lifeGauge = transform.Find("WorldCanvas").Find("LifeGauge").GetComponent<Image>();
    }

    public void SetupDestroyable(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }

    public void Interact()
    {
        TakeHit();
    }

    private void TakeHit()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 1;
            lifeGauge.fillAmount = (float)(currentHealth / maxHealth);
            Debug.Log("Interacting, currentLife:" + currentHealth);

            if (currentHealth <= 0) Die();
        }
    }

    private void Die()
    {
        OnDestroy?.Invoke();
    }
}
