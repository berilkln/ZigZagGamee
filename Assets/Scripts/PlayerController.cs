using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 yon = Vector3.left;
    public GroundSpawner groundSpawner;
    public static bool isDead = false;
    public float hizlanmaZorlugu;



    private void Update()
    {
        if (isDead)
        {
            return;
        }


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

        if(transform.position.y < 0.1f)
        {
            isDead = true;
            
            Destroy(this.gameObject,3f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime; //objenin hareket değeri.
        speed += Time.deltaTime * hizlanmaZorlugu;
        transform.position += hareket; //hareket değeri sürekli pozisyona eklenir.
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(YokEt(collision.gameObject));
            groundSpawner.ZeminOlustur();
        }
    }

    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();


        yield return new WaitForSeconds(0.4f);
        Destroy(zemin);
    }

















}
