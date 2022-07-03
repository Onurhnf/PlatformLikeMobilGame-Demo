using System.Collections;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    public bool isDead = false;
    public bool hurtAble = true; // unhurtable buff yapacaðým için public yaptým unutma!!
    [HideInInspector]
    public bool unHurtBuffisActive=false;


    
    bool flashOpen;
    float flashLong = 0.5f;
    float flashCounter;
    SpriteRenderer playerSprite;



    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {


        FlashPlayer();





    }

    private void FlashPlayer()
    {
        if (flashOpen)
        {
            if (flashCounter > flashLong * 5 / 6)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }

            else if (flashCounter > flashLong * 4 / 6)
            {
                playerSprite.color = new Color(1f, 1f, 1f);

            }

            else if (flashCounter > flashLong * 3 / 6)
            {
                playerSprite.color = new Color(1f, 1f, 1f, 0f);
            }
            else if (flashCounter > flashLong * 2 / 6)
            {
                playerSprite.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (flashCounter > flashLong * 1 / 6)
            {
                playerSprite.color = new Color(1f, 1f, 1f, 0f);
            }

            else
            {
                flashOpen = false;
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }

            flashCounter -= Time.deltaTime;
        }
    }


    public void HurtingPlayer(int damage,float sec)
    {
        if (hurtAble && currentHealth>0)
        {
            currentHealth -= damage;
            
            flashOpen = true;
            flashCounter = flashLong;
            print("Health "+currentHealth);

            StartCoroutine(SetHurtable(sec));

            
        }
        //TODO unhurtable buff yazmaya gerek var mý?

    }

    //TODO kill the player!!
    IEnumerator SetHurtable(float sec)
    {
        if (!unHurtBuffisActive)
        {
            hurtAble = false;
            yield return new WaitForSeconds(sec);
            hurtAble = true;
        }
        //TODO else waitforsec 10 ? 



    }




}
