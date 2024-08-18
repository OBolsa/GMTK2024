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
    [SerializeField]
    private Animator ResourceAnimator;
    [SerializeField]
    private ParticleSystem PfxHit;
    [SerializeField]
    private ParticleSystem PfxDeath;

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
            currentHealth -= 1;
            lifeGauge.fillAmount = (float)(currentHealth / maxHealth);
            if (myParticles != null) myParticles.PlayVFX();
            AudioManager.instance.PlaySfx(SFXs.SMASH_BUMP);
            InstantMessageHandler.instance.ShowMessage("Broke the box! ");
            PfxHit.Play();
            ResourceAnimator.SetTrigger("hit");
            if (currentHealth <= 0) Die();
        }
    }

    public void DestroySFX()
    {
        AudioManager.instance.PlaySfx(SFXs.BOX_CRASH);

    }

    private void Die()
    {
        PfxDeath.transform.parent = null;
        PfxDeath.Play();
        OnDestroy?.Invoke();
    }
}
