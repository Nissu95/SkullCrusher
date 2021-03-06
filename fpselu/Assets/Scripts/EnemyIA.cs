using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float raycastDist;
    [SerializeField] private LayerMask layers;
    [SerializeField] private string targetTagName;
    [SerializeField] private float distanceDamage;
    [SerializeField] private float timeNextAttack;
    [SerializeField] private float stunnTime;
    [SerializeField] private BoxCollider swordCollider;
    
    private float attackTimer = 0;
    private float stunnTimer = 0;
    private EnemyHealth eHealth;
    private Animator anim;
    private CharacterController characterController;

    void Start()
    {
        swordCollider.enabled = false;
        anim = GetComponent<Animator>();
        eHealth = GetComponent<EnemyHealth>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateTimers();

        characterController.Move(Vector3.down);

        Vector3 mov = Vector3.zero;

        if (stunnTimer <= 0 && eHealth.IsAlive())
        {

            Vector3 diff = PlayerManager.singleton.GetPlayerInstance().transform.position - transform.position;
            float dist = diff.magnitude;
            Vector3 dir = diff.normalized;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, raycastDist, layers))
            {
                if (hit.distance <= distanceDamage)
                {
                    anim.SetBool("isWalking", false);
                    if (attackTimer <= 0 && eHealth.IsAlive())
                    {
                        swordCollider.enabled = true;
                        anim.SetTrigger("Attack");
                        attackTimer = timeNextAttack;
                    }
                }
                else
                {
                    if (hit.collider.tag == targetTagName)
                    {
                        diff.y = 0;
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), 0.1f);

                        mov = dir * speed * Time.deltaTime;
                        mov = Vector3.ClampMagnitude(mov, dist);
                        
                        if (!anim.GetBool("isWalking"))
                            anim.SetBool("isWalking", true);
                    }
                    else if (anim.GetBool("isWalking"))
                        anim.SetBool("isWalking", false);
                }
            }

            if (!hit.collider)
            {
                if (anim.GetBool("isWalking"))
                    anim.SetBool("isWalking", false);
                return;
            }
        }
        else
        {
            if (anim.GetBool("isWalking"))
                anim.SetBool("isWalking", false);
        }


        characterController.Move(mov);
    }

    void UpdateTimers()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (stunnTimer > 0)
            stunnTimer -= Time.deltaTime;
    }

    public void Stunn()
    {
        stunnTimer = stunnTime;
    }

    public void Damaged()
    {
        raycastDist = Mathf.Infinity;
    }
}