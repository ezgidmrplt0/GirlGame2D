using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class diyalogKodları : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // Diyalog yazısı için
    public GameObject dialogPanel; // Diyalog panelini aktif/pasif yapmak için

    private string[] sentences = new string[]
    {
        "Sonunda… kendi evime taşındım.",
        "Artık kendime ait bir evrenim var…",
        "Eşyaları yerleştirdim.Şimdi sırada anı kutusuna koyacağım özel eşyalar var."
    };

    private int currentSentenceIndex = 0;

    void Start()
    {
        dialogPanel.SetActive(true);
        StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextSentence();
        }
    }

    void ShowNextSentence()
    {
        if (currentSentenceIndex < sentences.Length - 1)
        {
            currentSentenceIndex++;
            dialogText.text = ""; // Eski yazıyı sil
            StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
        }
        else
        {
            dialogPanel.SetActive(false); // Diyalog bittiğinde paneli kapat
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f); // Yazı efekti
        }
    }

    public void StartNewDialog(string[] newSentences)
    {
        StopAllCoroutines(); // Önceki diyalog durdurulsun
        dialogPanel.SetActive(true);
        sentences = newSentences;
        currentSentenceIndex = 0;
        StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
    }
}
