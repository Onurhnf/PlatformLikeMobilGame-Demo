using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DoorButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private Player player;
    Color colors;
    private Image image;
    bool pressed = false;
    public GameObject[] playerMove;
    public float center;
    float x;
    


    public void OnPointerClick(PointerEventData eventData)
    {
        pressed = true;
    }




    public void OnPointerDown(PointerEventData eventData)
    {
        image.color = new Color(255, 255, 255, 140);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.color = colors;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        colors = GetComponent<Image>().color;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (pressed)
        {
            
            useDoor();
            player.Move(x);
        }
    }
    private void deActive()
    {

        playerMove[1].GetComponent<MoveButton>().enabled = false;
        playerMove[2].GetComponent<MoveButton>().enabled = false;
        playerMove[3].GetComponent<AttackButton>().enabled = false;
        playerMove[4].GetComponent<JoyButton>().enabled = false;

    }
    public void useDoor()
    {
        deActive();
        if (player.transform.position.x + 0.1f <center)
        {
            x = 0.3f;

        }
        else if (player.transform.position.x - 0.1f > center)
        {
            x = -0.3f;
        }
        else
        {
            x = 0f;
            player.GetComponent<Animator>().SetTrigger("IsDoor");
        }

    }
    public void getobj(float obje)
    {
        center = obje;
    }

   

}
