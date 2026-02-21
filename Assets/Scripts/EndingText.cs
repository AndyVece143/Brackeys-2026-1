using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class EndingText : MonoBehaviour
{
    public TMP_Text text;
    public bool begin = false;
    public float duration;
    public bool clickable = false;
    public LevelLoader loader;
    public string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (begin == true)
        {
            StartCoroutine(waiter());
        }

        if (clickable == true && Input.GetMouseButtonDown(0))
        {
            loader.LoadNextLevel(sceneName);
        }
    }

    IEnumerator waiter()
    {
        begin = false;
        float timer = 0f;
        Color startColor = text.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        Debug.Log("Liberal");

        while (timer < duration)
        {
            timer += Time.deltaTime;
            text.color = Color.Lerp(startColor, endColor, timer / duration);
            yield return null;
        }
        clickable = true;
        //Hi chris how are you?
        //Hi colin how are you?
        //Hi ryan how are you?
    }
}
