using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControl : MonoBehaviour
{
    public SoundALL soundplayer;

    [Header("Script lien quan")]
    public Player Hp;
    public PlayerMoving isJump;
    public PlayerComBat isAtk;
    bool isone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp.currentHealth <= 0)
        {
            if (!isone)
            {
                soundplayer.PlaySound(2);
                isone = true;
            }
        }
        else if(isAtk.soundAttack)
        {
            soundplayer.PlaySound(0);
            isAtk.soundAttack = false;
        }
        else if(isJump.playerSoundjump)
        {
            soundplayer.PlaySound(1);
            isJump.playerSoundjump = false;
        }
    }
    public void soundKey()
    {
        soundplayer.PlaySound(3, 1f);
    }
        
            
            
        
    
}
