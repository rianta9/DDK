using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiaKhoaScript : MonoBehaviour
{
    public Image image;

   
    void ChiaKhoaOn()
    {
        image.color = Color.white;
        Destroy(gameObject);
    }
}
