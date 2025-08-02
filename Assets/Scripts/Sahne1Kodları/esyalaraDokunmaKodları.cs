using System.Collections;
using UnityEngine;

public class esyalaraDokunmaKodları : MonoBehaviour
{
    [Tooltip("Etkileşim metinleri")]
    public string[] interactionSentences;

    [Tooltip("Eğer sahnede birden fazla varsa doğrudan atamak daha güvenli: (opsiyonel)")]
    public diyalogKodları dialogController; // tercihen Inspector'dan bağla

    private SpriteRenderer spriteRenderer;
    private esyaYonetici esyaYonetici;

    [Tooltip("Bu eşya son eşya mı?")]
    public bool isSonEsya = false;

    private bool isProcessing = false; // tekrar tıklamayı engellemek için

    void Awake()
    {
        // Performans için FindObjectOfType'ları Awake/Start'ta yalnızca varsa al.
        if (dialogController == null)
        {
            dialogController = FindObjectOfType<diyalogKodları>();
        }

        esyaYonetici = FindObjectOfType<esyaYonetici>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (isProcessing) return; // zaten işleniyor

        if (dialogController == null)
        {
            Debug.LogError("diyalogKodları bulunamadı!");
            return;
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer bulunamadı!");
            return;
        }

        isProcessing = true;

        dialogController.StartNewDialog(interactionSentences);
        StartCoroutine(FadeOutAndDisable());
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

        // Tamamen şeffaf yap
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        gameObject.SetActive(false);

        if (esyaYonetici != null)
        {
            if (isSonEsya)
            {
                esyaYonetici.SonEsyaYokEdildi();
            }
            else
            {
                esyaYonetici.EsyaYokEdildi();
            }
        }
        else
        {
            Debug.LogWarning("esyaYonetici bulunamadı, yok etme bildirimi yapılmadı.");
        }
    }
}
