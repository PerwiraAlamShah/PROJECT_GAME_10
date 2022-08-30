using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float Jump = 14f;
    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        UpdateAnimation();
    }

    #region Movement
    void Movement()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
        }
    }
    #endregion

    #region UpdateAnimation
    void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            sprite.flipX = false;
            anim.SetBool("Run", true);
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    #endregion
}
