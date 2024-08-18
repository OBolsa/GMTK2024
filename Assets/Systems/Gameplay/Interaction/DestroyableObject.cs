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
    private ParticleHander myParticles;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        lifeGauge = transform.Find("WorldCanvas").Find("LifeGauge").GetComponent<Image>();
        myParticles = GetComponent<ParticleHander>();
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
            float playerDamage = LevelManager.Instance.attributes.GetPlayerDamage();

            currentHealth -= 1;
            lifeGauge.fillAmount = (float)(currentHealth / maxHealth);
            if (myParticles != null) myParticles.PlayVFX();
            AudioManager.instance.PlaySfx(SFXs.SMASH_BUMP);
            InstantMessageHandler.instance.ShowMessage("Broke the box! ");

            if (currentHealth <= 0) Die();
        }
    }

    public void DestroySFX()
    {
        AudioManager.instance.PlaySfx(SFXs.BOX_CRASH);

    }

    private void Die()
    {
        OnDestroy?.Invoke();
    }
}
