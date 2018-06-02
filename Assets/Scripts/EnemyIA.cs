using UnityEngine;

public class EnemyIA : MonoBehaviour
{

    [SerializeField] private Transform tr_Player;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float raycastDist;
    [SerializeField] private LayerMask layers;
    [SerializeField] private string targetTagName;
    [SerializeField] private float distanceDamage;
    [SerializeField] private float timeNextAttack;

    private float attackTimer = 0;
    private Animator anim;
    
    void Start() {
        anim = GetComponent<Animator>();
    }
    
    void Update() {

        Vector3 diff = tr_Player.position - transform.position;
        float dist = diff.magnitude;
        Vector3 dir = diff.normalized;

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, raycastDist, layers))
        {
            if (hit.distance <= distanceDamage )
            {
                if (attackTimer <= 0)
                {
                    anim.SetTrigger("Attack");
                    attackTimer = timeNextAttack;
                }
                else
                {
                    anim.SetBool("isWalking", false);
                }
                
            }
            else
            {
                if (hit.collider.tag == targetTagName)
                {
                    diff.y = 0;

                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), 0.1f);

                    Vector3 mov = dir * speed * Time.deltaTime;
                    mov = Vector3.ClampMagnitude(mov, dist);
                    transform.position += mov;
                    anim.SetBool("isWalking", true);
                }
                else
                    anim.SetBool("isWalking", false);
            }
        }
        

        if (!hit.collider)
        {
            anim.SetBool("isWalking", false);
            return;
        }

        

        Debug.DrawLine(
            transform.position,
            transform.position + transform.forward * raycastDist, Color.yellow);
    }
}