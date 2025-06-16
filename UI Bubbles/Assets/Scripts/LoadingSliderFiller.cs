using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingSliderFiller : MonoBehaviour
{
    public Slider loadingSlider;
    public float fillDuration = 4f; 

    private void Start()
    {
        StartCoroutine(FillSlider());
    }

    private IEnumerator FillSlider()
    {
        float elapsed = 0f;
        loadingSlider.value = 0;

        while (elapsed < fillDuration)
        {
            elapsed += Time.deltaTime;
            loadingSlider.value = Mathf.Lerp(0, 100, elapsed / fillDuration);
            yield return null;
        }

        loadingSlider.value = 100;

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Menu");
    }
}
