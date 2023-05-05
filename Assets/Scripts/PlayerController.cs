using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 yon = Vector3.left;
    public GroundSpawner groundSpawner;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(yon.x == 0) //z ekseninde hareket
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back; 
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime; //objenin hareket değeri.
        transform.position += hareket; //hareket değeri sürekli pozisyona eklenir.
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            groundSpawner.ZeminOlustur();
        }
    }

















}
