using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyalaraDokunmaKodları : MonoBehaviour
{
    public string[] interactionSentences;
    private diyalogKodları dialogController;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        dialogController = FindObjectOfType<diyalogKodları>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (dialogController != null)
        {
            dialogController.StartNewDialog(interactionSentences);
            StartCoroutine(FadeOutAndDisable()); // Tıklanınca kaybolmaya başla
        }
    }

    System.Collections.IEnumerator FadeOutAndDisable()
    {
        float fadeDuration = 1.0f; // 1 saniyede kaybolsun
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
        gameObject.SetActive(false); // Tamamen yok et
    }
}
