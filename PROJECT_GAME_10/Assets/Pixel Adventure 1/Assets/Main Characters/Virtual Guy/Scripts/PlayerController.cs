using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    // Player Health
    private int playerHealth = 3;
    public TextMeshProUGUI textHealth;

    [SerializeField] private LayerMask jumpalbeGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float Jump = 14f;
    private float dirX;

    // Item Collection
    public GameObject hitEffect;
    private int orange = 0;
    public TextMeshProUGUI textScore;

    // Movement State
    private enum MovementState { idle, run, fall, jump, hit, death };
    private MovementState state = MovementState.idle;

    public GameObject deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
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

        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
            Debug.Log("Jump");
        }
    }

    #endregion

    #region UpdateAnimation
    void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            sprite.flipX = false;
            state = MovementState.run;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }
    #endregion

    #region IsGround
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpalbeGround);
    }
    #endregion

    #region onTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            playerHealth -= 1;
            textHealth.text = "" + playerHealth;
            if (playerHealth == 0)
            {
                Death();
            }

        }

        if (other.gameObject.CompareTag("Orange"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(other.gameObject);
            orange += 1;
            Debug.Log("Orange : " + orange);
            textScore.text = "" + orange;
        }
    }
    #endregion

    #region PlayerHealth
    private void Death()
    {
        // rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    #endregion







}
