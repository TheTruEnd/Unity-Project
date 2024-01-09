using System.Collections;
using System.Collections.Generic;
using GameTool;
using Unity.Mathematics;
using UnityEditor.U2D.Sprites;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject prifab;
    public float cooldown;
    public float timeShoot = 0.5f;

    private float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 20));
        cooldown = timeShoot;
        //rb.velocity = new Vector2(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }

        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            cooldown = timeShoot;
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, parent:null, transform.position).Disable(1);
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Block"))
        {
            Debug.Log("Collide with Block");
            Instantiate(prifab, new Vector3(0f, 0f), quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}