using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }
    TMPro.TMP_Text points;
    private float fadeSpeed = 1f;

    void Start()
    {
        points = GetComponent<TMPro.TMP_Text>();
        Save save = SaveManager.LoadSave();
    }

    void Update()
    {

        points.text = "x" + GameManager.Instance.score;
    }
    public void StartFadeOut()
    {
        StartCoroutine(FadeOut(fadeSpeed));
    }

    IEnumerator FadeOut(float fadeSpeed)
    {
        Color matColor = points.color;
        float alphaValue = points.color.a;

        while (points.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            points.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }

        points.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        GameManager.Instance.AddToScore(1);
        StartCoroutine(FadeIn(fadeSpeed));
    }

    IEnumerator FadeIn(float fadeSpeed)
    {
        Color matColor = points.color;
        float alphaValue = points.color.a;

        while (points.color.a < 1f)
        {
            alphaValue += Time.deltaTime / fadeSpeed;
            points.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        points.color = new Color(matColor.r, matColor.g, matColor.b, 1f);
    }
}
