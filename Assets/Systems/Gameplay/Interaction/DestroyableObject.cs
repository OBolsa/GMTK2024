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
    private ParticleHandler myParticles;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        lifeGauge = transform.Find("WorldCanvas").Find("LifeGauge").GetComponent<Image>();
        myParticles = GetComponent<ParticleHandler>();
    }

    public void SetupDestroyable(int currentHealth, int maxHealth)
    {
        if(lifeGauge != null) lifeGauge.fillAmount = 1;
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
        Instantiate(PfxDeath,transform.position, Quaternion.identity);
        OnDestroy?.Invoke();
    }
}
