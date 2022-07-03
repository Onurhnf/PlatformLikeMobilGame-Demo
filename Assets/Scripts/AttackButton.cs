using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AttackButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,IPointerUpHandler
{

    private Player player;
    Color colors;
    private Image image;
    [SerializeField] float coolDown = 0.4f;
    private float waitforCD = 0f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (waitforCD >= coolDown)
        {
            print(waitforCD);
            StartCoroutine(AttackCo());
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        waitforCD = 1f; //TODO eðer her levelde kalýcý bir saldýrý hýzý buff almayý eklersen kaldýr / deðiþtir
        player = FindObjectOfType<Player>();
        colors = GetComponent<Image>().color;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        waitforCD += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            StartCoroutine(AttackCo());
        }
    }

    public IEnumerator AttackCo()
    {

        player.anim.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(0.2f);
        waitforCD = 0f;
        
        player.anim.SetBool("IsAttacking", false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.color = new Color(255, 255, 255, 140);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.color = colors;
    }
}
