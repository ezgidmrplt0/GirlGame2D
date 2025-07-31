using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyaYonetici : MonoBehaviour
{
    public List<GameObject> esyalar; // �nce yok olacak e�yalar
    public GameObject sonEsya;       // Sonradan ortaya ��kacak e�ya

    private int yokEdilenSayisi = 0;

    public void EsyaYokEdildi()
    {
        yokEdilenSayisi++;

        if (yokEdilenSayisi >= esyalar.Count)
        {
            StartCoroutine(SonEsyaGecikmeliGoster());
        }
    }

    IEnumerator SonEsyaGecikmeliGoster()
    {
        yield return new WaitForSeconds(3f); // 1 saniye bekle
        sonEsya.SetActive(true); // Son e�ya ortaya ��ks�n
    }

}
