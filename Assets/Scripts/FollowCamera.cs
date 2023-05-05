using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 distance;


    private void Start()
    {
        distance = transform.position - target.transform.position; // Kamera ile player arası mesafe.
    }


    private void LateUpdate()
    {
        if (PlayerController.isDead) //takip işlemini sonlandırır.
        {
            return;
        }
        transform.position = target.transform.position + distance;
    }
}
