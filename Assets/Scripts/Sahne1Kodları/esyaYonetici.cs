using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyaYonetici : MonoBehaviour
{
    public List<GameObject> esyalar; // �nce yok olacak e�yalar
    public GameObject sonEsya;       // Sonradan ortaya ��kacak e�ya
    public GameObject spiralGorseli; // Spiral g�rseli GameObject'i

    private int yokEdilenSayisi = 0;

    void Start()
    {
        if (spiralGorseli != null)
        {
            spiralGorseli.SetActive(false); // Oyun ba��nda spiral g�rseli pasif
            Debug.Log("Spiral g�rseli ba�lang��ta pasif yap�ld�.");
        }
        else
        {
            Debug.LogError("SpiralGorseli atanmam��! L�tfen Inspector'da spiral g�rselini ba�lay�n.");
        }

        if (sonEsya != null)
        {
            sonEsya.SetActive(false); // Son e�ya ba�lang��ta pasif
        }
    }

    public void EsyaYokEdildi()
    {
        yokEdilenSayisi++;
        Debug.Log($"Yok edilen e�ya say�s�: {yokEdilenSayisi}/{esyalar.Count}");

        if (yokEdilenSayisi >= esyalar.Count && sonEsya != null)
        {
            StartCoroutine(SonEsyaGecikmeliGoster());
        }
    }

    public void SonEsyaYokEdildi()
    {
        Debug.Log("Son e�ya yok edildi, spiral g�rseli g�sterilecek.");
        StartCoroutine(SpiralGorseliGecikmeliGoster());
    }

    IEnumerator SonEsyaGecikmeliGoster()
    {
        yield return new WaitForSeconds(3f); // 3 saniye bekle
        if (sonEsya != null)
        {
            sonEsya.SetActive(true); // Son e�ya ortaya ��ks�n
            Debug.Log("Son e�ya aktif edildi.");
        }
    }

    IEnumerator SpiralGorseliGecikmeliGoster()
    {
        yield return new WaitForSeconds(3f); // 3 saniye bekle
        if (spiralGorseli != null)
        {
            spiralGorseli.SetActive(true); // Spiral g�rselini aktif yap
            Debug.Log("Spiral g�rseli aktif edildi.");
        }
        else
        {
            Debug.LogError("SpiralGorseli null, aktif edilemedi!");
        }
    }
}