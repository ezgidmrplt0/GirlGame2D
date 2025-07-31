using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpiralKod : MonoBehaviour
{
    public Animator animator;
    public float effectDuration = 2f; // 1 saniye sonra sahne geçiþi
    public string nextSceneName;

    void Start()
    {
        StartCoroutine(PlayEffectAndLoadScene());
    }

    IEnumerator PlayEffectAndLoadScene()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(effectDuration);
        SceneManager.LoadScene(nextSceneName);
    }
}
