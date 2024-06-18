using UnityEngine;

public class Particle : MonoBehaviour
{
    ParticleSystem clickParticle;

    private void Awake()
    {
        clickParticle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        GameManager.Instance.mainParticle = this;
        GameManager.Instance.ClickEvent += PlayParticle;
    }
    
    public void PlayParticle(long temp)
    {
        clickParticle.Play();
    }
}