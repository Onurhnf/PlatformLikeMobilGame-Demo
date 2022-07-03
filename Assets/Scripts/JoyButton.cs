using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool pointerDown;
    private float pointerDownTimer;
    private Image image;
    [SerializeField]
    private float requiredHoldTime;
    Color colors;

    public UnityEvent onLongClick;


    private Player player;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        image.color = new Color(255, 255, 255, 140);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        pointerDown = true;
        image.color = new Color(255, 255, 255, 140);
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
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.Jump();
        }


        if (player.anim.GetBool("IsDead")==true)
        {
            return;
        }

        if (pointerDown)
        {

            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }

            player.Jump();


        }
    }

    public void Reset()
    {
        image.color = colors;
        player.isGrounded = false;
        player.isJumping = false;
        pointerDown = false;
        pointerDownTimer = 0;

    }


}