using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public Color[] colors;
    Color ilkRenk, ikinciRenk;
    int birinciRenk;

    public Material zeminMat;
    private void Start()
    {
        birinciRenk = Random.Range(0, colors.Length);
        ikinciRenk = colors[IkinciRenkSec()];
        zeminMat.color = colors[birinciRenk];
        Camera.main.backgroundColor = colors[birinciRenk];

    }
    private void Update()
    {
        Color fark = zeminMat.color - ikinciRenk;
        if (Mathf.Abs(fark.r) + Mathf.Abs(fark.g)+ Mathf.Abs(fark.b) < 0.2f)
        {
            ikinciRenk = colors[IkinciRenkSec()]; //renk oluştur
        }
        zeminMat.color = Color.Lerp(zeminMat.color,ikinciRenk,0.0003f);  //zemin rengini yeni renge aktarıp gecis sağlanır
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.0007f);
    }

    int IkinciRenkSec()
    {
        int ikinciRenkIndex;
        ikinciRenkIndex = Random.Range(0, colors.Length);
        while (ikinciRenkIndex == birinciRenk)
        {
            ikinciRenkIndex = Random.Range(0, colors.Length);
        }

        return ikinciRenkIndex;
    }








}//class
