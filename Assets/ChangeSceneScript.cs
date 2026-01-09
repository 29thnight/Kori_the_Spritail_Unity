using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeSceneScript : MonoBehaviour
{
    [SerializeField] float changeSceneTime;
    [SerializeField] Image transit_Img;

    private static void SetAlpha(Image img, float alpha)
    {
        if (img != null)
        {
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (transit_Img != null)
        {
            transit_Img.raycastTarget = false;
            SetAlpha(transit_Img, 0f); // ⭐ 시작 알파 0
        }

        StartCoroutine(FadeAndChangeScene());
    }

    IEnumerator FadeAndChangeScene()
    {
        yield return FadeTo(transit_Img, 1f, changeSceneTime);
        SceneManager.LoadScene("TitleScene");
    }


    private IEnumerator FadeTo(Image img, float targetAlpha, float sec)
    {
        if (null == img) yield break;

        float start = img.color.a;
        float t = 0f;
        float inv = sec > 0f ? 1f / sec : 0f;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * inv;
            float a = Mathf.Lerp(start, targetAlpha, Mathf.Clamp01(t));
            SetAlpha(img, a);
            yield return null;
        }

        SetAlpha(img, targetAlpha);
    }
}
