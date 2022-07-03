using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool pointerDown;
    private Image image;
    private float x;
    Color colors;



    private Player player;

    public void OnPointerEnter(PointerEventData eventData)
    {

        pointerDown = true;
        image.color = new Color(255, 255, 255, 140);

        if (eventData.pointerEnter.name == "LeftArrow")
        {
            x = -1f;
        }
        else if (eventData.pointerEnter.name == "RightArrow")
        {
            x = 1f;
        }
        else
        {
            x = 0f;
        }



    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Reset();

    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        image = GetComponent<Image>();
        colors = GetComponent<Image>().color;
    }
    private void FixedUpdate()
    {
        if (player.anim.GetBool("IsDead") == true)
        {
            return;
        }
        if (pointerDown)
        {
            
            player.Move(x);
        }
    }

    public void Reset()
    {
        player.Move(0);
        image.color = colors;

        pointerDown = false;

    }


}