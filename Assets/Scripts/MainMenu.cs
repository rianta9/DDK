using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public Animator animatorLoadScene;
    public float TimeLoad = 1f;
   public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadNext(0));
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    IEnumerator LoadNext(int levelLoad)
    {
        animatorLoadScene.SetTrigger("Start");
        yield return new WaitForSeconds(TimeLoad);
        SceneManager.LoadScene("Map0");
    }
}
