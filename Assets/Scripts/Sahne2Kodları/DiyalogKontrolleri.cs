using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro kullanýmý


public class DiyalogKontrolleri : MonoBehaviour
{
    public TextMeshProUGUI diyalogText;
    public GameObject diyalogPanel;
    public string[] diyaloglar;

    private int diyalogIndex = 0;
    private bool yaziliyor = false;
    private float yazmaHizi = 0.05f; // Harf hýzý (0.05 saniye)

    void Start()
    {
        diyalogPanel.SetActive(true);
        diyalogIndex = 0;
        StartCoroutine(YaziYaz(diyaloglar[diyalogIndex]));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!yaziliyor)
            {
                SonrakiDiyalog();
            }
        }
    }

    void SonrakiDiyalog()
    {
        diyalogIndex++;

        if (diyalogIndex < diyaloglar.Length)
        {
            StartCoroutine(YaziYaz(diyaloglar[diyalogIndex]));
        }
        else
        {
            diyalogPanel.SetActive(false);
        }
    }

    IEnumerator YaziYaz(string cumle)
    {
        yaziliyor = true;
        diyalogText.text = ""; // Metni temizle

        foreach (char harf in cumle.ToCharArray())
        {
            diyalogText.text += harf;
            yield return new WaitForSeconds(yazmaHizi);
        }

        yaziliyor = false;
    }
}
