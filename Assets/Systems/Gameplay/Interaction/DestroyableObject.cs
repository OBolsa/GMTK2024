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

    AudioClip hitSfx;


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

    public void SetupDestroyable(ItemInfo item)
    {
        if(lifeGauge != null) lifeGauge.fillAmount = 1;
        this.maxHealth = item.itemLife;
        this.currentHealth = this.maxHealth;
        this.hitSfx = item.itemSfx;
       
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
            AudioManager.instance.PlaySfx(hitSfx);

            if (currentHealth <= 0) Die();
        }
    }

    public void DestroySFX()
    {
        InstantMessageHandler.instance.ShowMessage("Got plus 1 resources! ");
        AudioManager.instance.PlaySfx(SFXs.BOX_CRASH);

    }

    private void Die()
    {
       OnDestroy?.Invoke();
    }
}
