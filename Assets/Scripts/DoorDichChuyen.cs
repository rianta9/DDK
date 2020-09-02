using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDichChuyen : MonoBehaviour
{
    [Header("DichChuyen")]
    public GameObject VatDichChuyen;
    public Transform DiaDiemToi;
    bool isPlayerOnDoor = false;
    bool GoTeleport = false;
    
    [Header("Camera Limit")]
    public CameraFlow cam;
    public Vector2 minpos;
    public Vector2 maxpos;

    [Header("Player")]
    public Player player;
    [Header("DoorBoss?")]
    public bool KeyBoss = false;

    [Header("Text")]
    public Text TextGioiThieu;
    public string NoiDungClose,NoiDungOpen,defaul = "Không Có Chìa Khóa";

    


    bool IsOpen = false;
    void Start()
    {
        
            
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOpen && GoTeleport && isPlayerOnDoor)
        {
            if(player.IsKey && !KeyBoss)
            {
                gameObject.GetComponent<Animator>().SetBool("Open", true);
                IsOpen = true;
                GoTeleport = false;
                

            }
            else
            if (!player.IsKey || KeyBoss)
            {
                TextGioiThieu.text = defaul;
            }
        }
        
        if (isPlayerOnDoor && IsOpen)
        {
            if (GoTeleport)
            {
                VatDichChuyen.transform.position = DiaDiemToi.position;
                cam.minpos = minpos;
                cam.maxpos = maxpos;
                GoTeleport = false;
                cam.transform.position = new Vector3(DiaDiemToi.position.x,DiaDiemToi.position.y,cam.transform.position.z);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(VatDichChuyen.tag))
        {
            isPlayerOnDoor = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(VatDichChuyen.tag))
        {
            if (!IsOpen)
            {
                TextGioiThieu.text = NoiDungClose;
            }
            if (IsOpen)
            {
                TextGioiThieu.text = NoiDungOpen;
            }
            isPlayerOnDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(VatDichChuyen.tag))
        {
            isPlayerOnDoor = false;
            GoTeleport = false;
            TextGioiThieu.text = "";
        }
    }
    void DichChuyen()
    {
       
        if(isPlayerOnDoor)
          GoTeleport = true;
    }
    public void OpenDoor(bool isOpen)
    {
        IsOpen = true;
        gameObject.GetComponent<Animator>().SetBool("Open", IsOpen);
        GoTeleport = false;
    }
    
    
    
}
