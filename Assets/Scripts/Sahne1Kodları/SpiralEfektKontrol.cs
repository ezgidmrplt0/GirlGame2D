using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpiralEfektKontrol : MonoBehaviour
{
    public GameObject spiralEfekt; // Spiral objesi
    private bool spiralGorunuyor = false;
    private bool efektBasladi = false;

    void Start()
    {
        spiralEfekt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !efektBasladi)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("yumru"))
            {
                efektBasladi = true;
                StartCoroutine(SpiralGoster());
            }
        }

        if (spiralGorunuyor && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Sahne2");
        }
    }

    IEnumerator SpiralGoster()
    {
        yield return new WaitForSeconds(3f);
        spiralEfekt.SetActive(true);
        spiralGorunuyor = true;
    }
}
