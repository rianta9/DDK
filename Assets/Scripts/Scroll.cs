using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void FixedUpdate()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();  
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset; // offset hiện tại 
        offset.x = player.transform.position.x; // nếu người chơi di chuyển thi quả cầu di chuyển theo 
        mat.mainTextureOffset = offset * Time.fixedDeltaTime / 0.42f;// gán lại vị trị offes của quả cầu thành vị trí hiện tại của người chới
    }
}
