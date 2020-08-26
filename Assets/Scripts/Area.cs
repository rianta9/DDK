using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Script này dùng để xác định người chơi có đang vào trong một khu vực hay không
 */

public class Area : MonoBehaviour
{
    public bool isInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = false;
    }
}
