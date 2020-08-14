using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BirdFlow : MonoBehaviour
{
    [Range(0, 0.3f)] [SerializeField] private float smoothtimeX = .03f;
    [Range(0, 0.3f)] [SerializeField] private float smoothtimeY = .03f;

    public GameObject player;
    public GameObject bird;
    public Transform flowpoint;
    public LayerMask enemyLayers;
    public bool bound;
    public float FlowRange = 0.5f;
    bool faceright = true;
    float uplen = 1f;

    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bird = GameObject.FindGameObjectWithTag("Bird");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D colliders = Physics2D.OverlapCircle(flowpoint.position, FlowRange, enemyLayers);

        if(colliders == null)
        {
            bound = true;
        }
        else
        {
            bound = false;
        }
        if (bird.transform.position.x > player.transform.position.x && faceright)
        {
            Flip();
        }
        if (bird.transform.position.x < player.transform.position.x && !faceright)
        {
            Flip();
        }
        if (bound)
        {
            float posX = Mathf.SmoothDamp(bird.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
            float posY = Mathf.SmoothDamp(bird.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
            bird.transform.position = new Vector3(posX, posY, bird.transform.position.z);
            
            
            if(uplen < 1f)
            {
                uplen += 0.1f;
            }
        }
        else
        {
            if(uplen > 0)
            {
                bird.transform.position = new Vector3(bird.transform.position.x, bird.transform.position.y + (1f * Time.fixedDeltaTime), bird.transform.position.z);
                uplen -= (1f * Time.fixedDeltaTime);
            }
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (flowpoint == null)
            return;

        Gizmos.DrawWireSphere(flowpoint.position, FlowRange);
    }
    private void Flip()
    {
        faceright = !faceright;
        bird.transform.Rotate(0f, 180f, 0f);
    }
}
