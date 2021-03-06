using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] string enemyTag;
    [SerializeField] float swordDamage;
    [SerializeField] float attackCooldown;
    [SerializeField] string[] attackParameters;
    [SerializeField] AudioClip swordSound;

    AudioSource aS;
    private Animator anim;
    BoxCollider swordCollider;
    float timer;

    void Start()
    {
        aS = GetComponentInParent<AudioSource>();
        swordCollider = GetComponent<BoxCollider>();
        swordCollider.enabled = false;
        timer = attackCooldown;
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && timer >= attackCooldown)
        {
            aS.PlayOneShot(swordSound);
            swordCollider.enabled = true;
            anim.SetTrigger(attackParameters[Random.Range(0,attackParameters.Length-1)]);
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            swordCollider.enabled = false;
            string enemyName = other.GetComponent<EnemyDT>().data.name;
            string playerElementName = PlayerManager.singleton.GetName();
            other.GetComponent<EnemyHealth>().TakeDamage(PlayerManager.singleton.GetDamage() * BattleManager.singleton.ElementMultiplier(playerElementName, enemyName));
        }
    }

}
