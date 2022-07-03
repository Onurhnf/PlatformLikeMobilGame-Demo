using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int damageValue=1;
    //public GameObject whatisHurting;// her hasar veren ayn� s�re boyunca dokunulmaz yapmas�n diye **TAG KULLAN**
    public float DamageCoolDown=1f;

    Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
    }




    private void OnTriggerStay2D(Collider2D collision)
    {



        if (collision.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerHealthControl>().HurtingPlayer(damageValue, DamageCoolDown);
            theRB.WakeUp();

        }






    }







}
