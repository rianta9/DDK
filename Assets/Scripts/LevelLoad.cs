using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progressText;
    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsy(SceneIndex));
    }
    IEnumerator LoadAsy(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
        
    }
}
