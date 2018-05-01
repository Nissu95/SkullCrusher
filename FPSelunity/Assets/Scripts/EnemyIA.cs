using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyIA : MonoBehaviour
{

    [SerializeField] private Transform tr_Player;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float raycastDist;
    [SerializeField] private LayerMask layers;
    [SerializeField] private string targetTagName;
    
    void Start() {
    }
    
    void Update() {

        Vector3 diff = tr_Player.position - transform.position;
        float dist = diff.magnitude;
        Vector3 dir = diff.normalized;

        RaycastHit hit;
        Physics.Raycast(transform.position, dir, out hit, raycastDist, layers);

        if (!hit.collider) return;

        if (hit.collider.tag == targetTagName)
        {
            diff.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), 0.1f);

            Vector3 mov = dir * speed * Time.deltaTime;
            mov = Vector3.ClampMagnitude(mov, dist);
            transform.position += mov;
        }

        Debug.DrawLine(
            transform.position,
            transform.position + transform.forward * raycastDist, Color.yellow);
    }
    /*
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raycastDist);
    }*/

}