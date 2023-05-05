using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Text scoreText,bestScoreTest;
    Vector3 yon = Vector3.left;
    public GroundSpawner groundSpawner;
    public static bool isDead = false;
    public float hizlanmaZorlugu;
    float score = 0f;
    float artisMiktari = 1f;
    int bestScore = 0;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");   //yapılan en iyi skoru hafızada tutar.
        bestScoreTest.text = "Best: " + bestScore.ToString();
    }




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
            if (bestScore < score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("BestScore", bestScore);

            }
            Destroy(this.gameObject,3f);


        }
    }

    private void FixedUpdate()
    {

        if (isDead) //karakter öldüyse aşağıdaki işlemler çalışmaz.
        {
            return;
        }
        Vector3 hareket = yon * speed * Time.deltaTime; //objenin hareket değeri.
        speed += Time.deltaTime * hizlanmaZorlugu;
        transform.position += hareket; //hareket değeri sürekli pozisyona eklenir.

        score +=artisMiktari * speed * Time.deltaTime; //float değeri int yaptık parantez içerisine alıp
        scoreText.text ="Score: "+ ((int) score).ToString();
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
