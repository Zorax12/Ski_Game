using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup screenOverlay;
    [SerializeField] private float fadeSpeed = 2;
    
    [SerializeField] private GameObject raceOverPanel;
    [SerializeField] private int nextLevelIndex = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenOverlay.gameObject.SetActive(true);
        raceOverPanel.SetActive(false);
        StartCoroutine(FadeOut());
    }

    private void OnEnable()
    {
        FinishGate.EndRace += OnRaceFinish;
    }

    private void OnDisable()
    {
        FinishGate.EndRace -= OnRaceFinish;
    }

    private void OnRaceFinish()
    {
        raceOverPanel.SetActive(true);
    }

    private IEnumerator FadeOut()
    {
        while (screenOverlay.alpha > 0)
        {
            screenOverlay.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
    
    private IEnumerator FadeIn()
    {
        while (screenOverlay.alpha < 1)
        {
            screenOverlay.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    public void Reset()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        yield return StartCoroutine(FadeIn());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        StartCoroutine(NexLevelCoroutine());
    }
    private IEnumerator NexLevelCoroutine()
    {
        yield return StartCoroutine(FadeIn());
        SceneManager.LoadScene(nextLevelIndex);
    }
    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(FadeIn());
        Application.Quit();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
