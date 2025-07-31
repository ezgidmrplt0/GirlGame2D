using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyaYonetici : MonoBehaviour
{
    public List<GameObject> esyalar; // Önce yok olacak eþyalar
    public GameObject sonEsya;       // Sonradan ortaya çýkacak eþya

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
        sonEsya.SetActive(true); // Son eþya ortaya çýksýn
    }

}
