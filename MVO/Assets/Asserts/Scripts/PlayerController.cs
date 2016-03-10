using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public GameObject bomb;
    List<GameObject> bombs;
    private Animator animator;
    private Rigidbody2D rb2D;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        bombs = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (bombs.Count < 1)
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                Vector3 pos = new Vector3(x, y, 0f);
                bombs.Add((GameObject)Instantiate(bomb, pos, Quaternion.identity));

            }
            else
            {
                Debug.Log("Only one is allowed");
            }

            //float x = Mathf.Floor(transform.position.x);
            //float y = Mathf.Ceil(transform.position.y);

        }
    }

    public void Move()
    {
        int horizontal = 0;
        int vertical = 0;
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }
        if (horizontal != 0 || vertical != 0)
        {
            Vector2 movement = new Vector2(horizontal, vertical);
            rb2D.transform.Translate(movement * moveSpeed);
            UpdateAnimation(horizontal, vertical);
        }
        else
        {
            UpdateAnimation(0, 0);
        }
    }

    public void UpdateAnimation(int horizontal, int vertical)
    {
        animator.SetBool("PlayerMoveRight", false);
        animator.SetBool("PlayerMoveLeft", false);
        animator.SetBool("PlayerMoveDown", false);
        animator.SetBool("PlayerMoveUp", false);

        if (horizontal > 0) { animator.SetBool("PlayerMoveRight", true); }
        else if (horizontal < 0) { animator.SetBool("PlayerMoveLeft", true); }
        else if (vertical > 0) { animator.SetBool("PlayerMoveUp", true); }
        else if (vertical < 0) { animator.SetBool("PlayerMoveDown", true); }
    }
}
