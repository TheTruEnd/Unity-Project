using GameTool;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject prifab;
    public float cooldown;
    public float timeShoot = 0.5f;

    private float jumpForce = 10f;
    
    public float boundTop = 5f;
    public float boundBottom = -5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 20));
        AudioManager.Instance.PlayMusic(eMusicName.Game_Music);
        cooldown = timeShoot;
        //rb.velocity = new Vector2(0, 20);
    }

    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.Shot(eSoundName.Jump);
            rb.velocity = new Vector2(0, jumpForce);
        }

        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            cooldown = timeShoot;
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, parent:null, transform.position).Disable(1);
        }

        if (gameObject.transform.position.y < -5 || gameObject.transform.position.y > 5)
        {
            Debug.Log("Death");
            // Application.Quit();
            UnityEditor.EditorApplication.isPaused = true;
        }

        // var pos = transform.position;
        //
        // if (pos.y >= boundTop)
        // {
        //     transform.position = new Vector2(pos.x, boundTop);
        // }
        // else if (pos.y <= boundBottom)
        // {
        //     transform.position = new Vector2(pos.x, boundBottom);
        // }
        
    }
    
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.transform.CompareTag("Block"))
    //     {
    //         Debug.Log("Death");
    //         // Instantiate(prifab, new Vector3(0f, 0f), quaternion.identity);
    //     }
    // }
    
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Block"))
    //     {
    //         rb.velocity = new Vector2(0, -30f);
    //     }
    // }
    
}