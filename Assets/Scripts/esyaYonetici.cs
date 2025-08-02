using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyaYonetici : MonoBehaviour
{
    public List<GameObject> esyalar; // Önce yok olacak eþyalar
    public GameObject sonEsya;       // Sonradan ortaya çýkacak eþya
    public GameObject spiralGorseli; // Spiral görseli GameObject'i

    private int yokEdilenSayisi = 0;

    void Start()
    {
        if (spiralGorseli != null)
        {
            spiralGorseli.SetActive(false); // Oyun baþýnda spiral görseli pasif
            Debug.Log("Spiral görseli baþlangýçta pasif yapýldý.");
        }
        else
        {
            Debug.LogError("SpiralGorseli atanmamýþ! Lütfen Inspector'da spiral görselini baðlayýn.");
        }

        if (sonEsya != null)
        {
            sonEsya.SetActive(false); // Son eþya baþlangýçta pasif
        }
    }

    public void EsyaYokEdildi()
    {
        yokEdilenSayisi++;
        Debug.Log($"Yok edilen eþya sayýsý: {yokEdilenSayisi}/{esyalar.Count}");

        if (yokEdilenSayisi >= esyalar.Count && sonEsya != null)
        {
            StartCoroutine(SonEsyaGecikmeliGoster());
        }
    }

    public void SonEsyaYokEdildi()
    {
        Debug.Log("Son eþya yok edildi, spiral görseli gösterilecek.");
        StartCoroutine(SpiralGorseliGecikmeliGoster());
    }

    IEnumerator SonEsyaGecikmeliGoster()
    {
        yield return new WaitForSeconds(3f); // 3 saniye bekle
        if (sonEsya != null)
        {
            sonEsya.SetActive(true); // Son eþya ortaya çýksýn
            Debug.Log("Son eþya aktif edildi.");
        }
    }

    IEnumerator SpiralGorseliGecikmeliGoster()
    {
        yield return new WaitForSeconds(3f); // 3 saniye bekle
        if (spiralGorseli != null)
        {
            spiralGorseli.SetActive(true); // Spiral görselini aktif yap
            Debug.Log("Spiral görseli aktif edildi.");
        }
        else
        {
            Debug.LogError("SpiralGorseli null, aktif edilemedi!");
        }
    }
}