using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // Duração da animação de fade-in
    public float fadeOutDuration = 1.0f; // Duração da animação de fade-out
    private CanvasGroup canvasGroup;

    private void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // Certifique-se de que o objeto comece invisível
        canvasGroup.alpha = 0;

        // Inicie a animação de fade-in
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float currentTime = 0;
        while (currentTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, 1, currentTime / fadeInDuration);
            canvasGroup.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }

        // Certifique-se de que o alpha esteja definido como 1 no final
        canvasGroup.alpha = 1;

        // Aguarde por algum tempo (opcional)
        yield return new WaitForSeconds(5.0f);

        // Inicie a animação de fade-out
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float currentTime = 0;
        while (currentTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1, 0, currentTime / fadeOutDuration);
            canvasGroup.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }

        // Certifique-se de que o alpha esteja definido como 0 no final
        canvasGroup.alpha = 0;

        // Desative o GameObject após o fade-out
        gameObject.SetActive(false);
    }
}
