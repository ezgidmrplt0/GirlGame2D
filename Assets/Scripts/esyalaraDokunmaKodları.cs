using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyalaraDokunmaKodları : MonoBehaviour
{
    public string[] interactionSentences;
    private diyalogKodları dialogController;
    private SpriteRenderer spriteRenderer;
    private esyaYonetici esyaYonetici;

    public GameObject efektImage; // Efekt image'ını Inspector’dan tanımla
    public bool isSonEsya = false; // Bu eşya son eşya mı?

    void Start()
    {
        dialogController = FindObjectOfType<diyalogKodları>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        esyaYonetici = FindObjectOfType<esyaYonetici>();
    }

    void OnMouseDown()
    {
        if (dialogController != null)
        {
            dialogController.StartNewDialog(interactionSentences);
            StartCoroutine(FadeOutAndDisable());

            if (isSonEsya && efektImage != null)
            {
                efektImage.SetActive(true); // Efekt çalışsın
            }
        }
    }

    IEnumerator FadeOutAndDisable()
    {
        float fadeDuration = 1.0f;
        float currentTime = 0f;
        Color originalColor = spriteRenderer.color;

        while (currentTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        gameObject.SetActive(false);

        if (esyaYonetici != null && !isSonEsya)
        {
            esyaYonetici.EsyaYokEdildi();
        }
    }
}
