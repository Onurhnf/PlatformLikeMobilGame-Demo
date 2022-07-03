using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float inputX;
    private Rigidbody2D theRB;

    private bool spawnDust;

    MapButton mapBtn;

    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isJumping;
    [HideInInspector]
    public Animator anim;

    public Transform feetPos;
    public LayerMask whatIsGround;
    public float jumpTime;
    public GameObject Dust;
    public CinemachineVirtualCamera cinemachine;

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float checkRadius;
    [SerializeField] private float playerHealth = 3f;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mapBtn = FindObjectOfType<MapButton>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {



        // Move(Input.GetAxis("Horizontal")); //TODO sillllllll ekran tuþunu engelliyor



    }

    private void Update()
    {
        

        if (anim.GetBool("IsDead") == true) { return; }
        if (anim.GetBool("IsAttacking"))
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        else
            JumpAnim();

        SpawnDust();
        PlayerDeath();
    }
    public void spawndustTrue()
    {
        spawnDust = true;
        GameObject clone = Instantiate(Dust, feetPos.position, Quaternion.identity);
        Destroy(clone, 0.5f);
        spawnDust = false;
    }

    private void SpawnDust() //spawns dust after jump complate
    {
        if (isGrounded)
        {
            if (spawnDust)
            {
                GameObject clone = Instantiate(Dust, feetPos.position, Quaternion.identity);
                Destroy(clone, 0.5f);
                spawnDust = false;
            }

        }
        else
        {
            spawnDust = true;
        }

    }

    private void JumpAnim()
    {


        if (theRB.velocity.y > 0.1f)
        {

            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", true);
            anim.SetBool("IsFalling", false);
        }
        else if (theRB.velocity.y < -0.1f)
        {

            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);

        }
        else
        {

            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);

        }
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            //Instantiate(Dust, feetPos.position, Quaternion.identity);
            theRB.velocity = new Vector2(0, Mathf.Sqrt(-5f * Physics2D.gravity.y * jumpForce));

            isJumping = true;
        }
        if (isJumping && theRB.velocity.y > 0.1)
        {
            theRB.velocity = new Vector2(0, Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpForce));
        }


    }

    public void Move(float horiz)
    {


        inputX = horiz;
        print(horiz);
        theRB.velocity = new Vector2(inputX * moveSpeed, theRB.velocity.y);
        //print(theRB.velocity);
        if (theRB.velocity.x > 0f)
        {
            transform.localScale = Vector3.one;
            anim.SetBool("IsRunning", true);
        }
        else if (theRB.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    private void PlayerDeath()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("IsDead", true);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
            anim.SetBool("IsAttacking", false);


        }
    }


    public IEnumerator Shakee()
    {



        cinemachine.m_Lens.OrthographicSize = 6.95f;


        yield return new WaitForSeconds(0.04f);

        cinemachine.m_Lens.OrthographicSize = 7f;


    }
    public void endLevel()
    {


        mapBtn.GameEnd(gameObject.GetComponent<PlayerHealthControl>().currentHealth);



    }




}
