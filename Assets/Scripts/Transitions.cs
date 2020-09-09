using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public Animator animatorTransitions;
    public float TimeWait = 1f;
    public int SceneCanLoad = 0;
   
    public void LevelLoadTransitions()
    {
        StartCoroutine(LevelLoadTransition(SceneCanLoad));
    }
    IEnumerator LevelLoadTransition(int SceneLevel)
    {
        animatorTransitions.SetTrigger("Start");
        yield return new WaitForSeconds(TimeWait);
        SceneManager.LoadScene(SceneLevel);
    }
}
