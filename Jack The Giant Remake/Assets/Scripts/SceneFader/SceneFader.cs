using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;
    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private Animator fadeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnimator.Play("FadeIn");

        yield return StartCoroutine(Coroutine.WaitForRealSeconds(1f));

        SceneManager.LoadScene(level);
        fadeAnimator.Play("FadeOut");

        yield return StartCoroutine(Coroutine.WaitForRealSeconds(0.7f));

        fadePanel.SetActive(false);
    }
}
