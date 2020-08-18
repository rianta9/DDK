using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Add script này vào đối tượng cửa qua màn tiếp theo.
 Set nextMap là chỉ số của màn chơi tiếp theo(Vào file -> build setting để xem chỉ số)
 */
public class Door : MonoBehaviour
{
    public int nextMap = 1;
    //public GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        //gm = new GameMaster();
        //gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaveScore();
            SceneManager.LoadScene(nextMap);
            //gm.inputText.text = "Press E to Enter";
        }
    }

    private void SaveScore()
    {
        //PlayerPrefs.SetInt("points", gm.points);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        if (Input.GetKey(KeyCode.E))
    //        {
    //            SaveScore();
    //            SceneManager.LoadScene(nextMap);
    //        }
    //    }
            
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gm.inputText.text = "";
        }
        
    }
}
