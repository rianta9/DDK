using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int points = 0;
    public int highScore;
    public Text textPoint;
    public Text hightText;
    public Text inputText;

    //TODO: Xóa hàm tạo khi có các đối tượng textPoint, hightText, inputText
    

    // Start is called before the first frame update
    //void Start()
    //{
    //    hightText.text = ("HighScorre: " + PlayerPrefs.GetInt("highScore"));
    //    highScore = PlayerPrefs.GetInt("highScore", 0);

    //    if (PlayerPrefs.HasKey("points"))
    //    {
    //        Scene activeScreen = SceneManager.GetActiveScene();
    //        if (activeScreen.buildIndex == 0)
    //        {
    //            PlayerPrefs.DeleteKey("points");
    //            points = 0;
    //        }
    //        else points = PlayerPrefs.GetInt("points");
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    textPoint.text = ("Point: " + points);
    //}
}
