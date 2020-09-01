using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_DoiThoai : MonoBehaviour
{
    [Header("TextNPC")]
    public Text TextNPC;
    public string NoiDungKhiCham,NoiDungTraLoiDung,NoiDungTraLoiSai;

    [Header("MucTieuNhiemVu")]
    public bool IsBossDie = false;

    bool PlayerNhanE = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerNhanE && IsBossDie)
        {
            TextNPC.text = NoiDungTraLoiDung;
        }
        else if(PlayerNhanE && !IsBossDie)
        {
            TextNPC.text = NoiDungTraLoiSai;
        }
        PlayerNhanE = false;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (!IsBossDie)
            {
                TextNPC.text = NoiDungTraLoiSai;
            }
            else 
            {
                TextNPC.text = NoiDungTraLoiDung;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TextNPC.text = "";
        }
    }
    void DoiThoai()
    {
        PlayerNhanE = true;
    }
}

    
    