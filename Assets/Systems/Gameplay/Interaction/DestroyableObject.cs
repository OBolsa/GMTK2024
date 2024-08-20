using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DestroyableObject : MonoBehaviour, IInteractable
{
    private Image lifeGauge;

    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    public Animator anim;
    public ParticleSystem feedbackHit;

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
        if (lifeGauge != null) lifeGauge.fillAmount = 1;
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
            FeedbackHit();

            if (currentHealth <= 0) Die();
        }
    }

    public void FeedbackHit()
    {
        Debug.Log("Feedback Hit!");

        if (anim != null)
        {
            anim.SetTrigger("hit");
        }

        if (feedbackHit != null)
        {
            feedbackHit.Play();
        }
    }

    public void DestroySFX()
    {
        InstantMessageHandler.instance.ShowMessage("Got plus 1 resources! ");

    }

    private void Die()
    {
        AudioManager.instance.PlaySfx(SFXs.SMASH_BUMP);
        OnDestroy?.Invoke();
    }
}
