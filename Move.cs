using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    float maxSpeed = 12f;
    float mvspd = 250f;
    int jmpspd = 2000;
    private Animator anim;
    public CullingMasks m;
    private Transform s;
    private float h;
    private bool facingRight;
    private bool grounded;
    private Transform groundCheck;
    private Transform pushCheck;
    private LayerMask jumpmask;
    public GameObject otherPlayer;


	void Start () {
        this.groundCheck = this.transform.Find("groundCheck");
        this.pushCheck = this.transform.Find("pushCheck");
        this.s = this.transform.Find("Sprite");
        this.anim = this.s.GetComponent<Animator>();
	}

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground") | 1 << jumpmask | 1 << LayerMask.NameToLayer("Normal")); 
            if (h < 0 && !facingRight)
                Flip();
            else if (h > 0 && facingRight)
                Flip();

            IgnoreCollisions();

    }
	void FixedUpdate () {
        if (gameObject.name == "Girl")
        {
            h = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(h));
            
            if (h * rigidbody2D.velocity.x < maxSpeed)
                rigidbody2D.AddForce(Vector2.right * h * mvspd);

            if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
                rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

            if (Input.GetButtonDown("X") && grounded == true || Input.GetButtonDown("Jump") && grounded == true)
            {
                Jump();
            }

            if (Input.GetButtonDown("Push"))
                Push();
        }

        if (gameObject.name == "Boy")
        {
            h = Input.GetAxis("Horizontal2");
            anim.SetFloat("Speed", Mathf.Abs(h));

            if (h * rigidbody2D.velocity.x < maxSpeed)
                rigidbody2D.AddForce(Vector2.right * h * mvspd);

            if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
                rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

            if (Input.GetButtonDown("X2") && grounded == true || Input.GetButtonDown("Jump2") && grounded == true)
            {
                Jump();
            }

            if (Input.GetButtonDown("Push2"))
                Push();
        }

	}

    void Jump()
    {
            rigidbody2D.AddForce(new Vector2(0f, jmpspd));
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void IgnoreCollisions()
    {
        #region GIRL
        if (m.selected.ToString() == "Sad" && gameObject.name == "Girl")
        {
            jumpmask = LayerMask.NameToLayer("Sad");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Sad"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Joy"));
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Angry"));
        }

        if (m.selected.ToString() == "Joy" && gameObject.name == "Girl")
        {
            jumpmask = LayerMask.NameToLayer("Joy");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Joy"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Sad"));
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Angry"));
        }

        if (m.selected.ToString() == "Angry" && gameObject.name == "Girl")
        {
            jumpmask = LayerMask.NameToLayer("Angry");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Angry"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Joy"));
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Sad"));
        }
        #endregion

        #region GIRL2
        if (m.selected.ToString() == "Sad" && gameObject.name == "Boy")
        {
            jumpmask = LayerMask.NameToLayer("Sad");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Sad"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Joy"));
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Angry"));
        }

        if (m.selected.ToString() == "Joy" && gameObject.name == "Boy")
        {
            jumpmask = LayerMask.NameToLayer("Joy");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Joy"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Sad"));
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Angry"));
        }

        if (m.selected.ToString() == "Angry" && gameObject.name == "Boy")
        {
            jumpmask = LayerMask.NameToLayer("Angry");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Angry"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Joy"));
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("Sad"));
        }
        #endregion

    }

    void Push()
    {
        //Debug.Log("Push");
        anim.SetTrigger("Push");
        if (this.gameObject.name == "Boy")
        {
            if (Physics2D.Linecast(transform.position, pushCheck.position, 1 << LayerMask.NameToLayer("Player")))
            {
                if(!facingRight)
                    otherPlayer.rigidbody2D.AddForce(new Vector2(40000f, 3000f));
                else
                    otherPlayer.rigidbody2D.AddForce(new Vector2(-40000f, 3000f));
            }
        }

        if (this.gameObject.name == "Girl")
        {
            if (Physics2D.Linecast(transform.position, pushCheck.position, 1 << LayerMask.NameToLayer("Player2")))
            {
                if (!facingRight)
                    otherPlayer.rigidbody2D.AddForce(new Vector2(40000f, 3000f));
                else
                    otherPlayer.rigidbody2D.AddForce(new Vector2(-40000f, 3000f));
            }
        }
    }
}
