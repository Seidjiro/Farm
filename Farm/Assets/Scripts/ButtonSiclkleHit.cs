using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSiclkleHit : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] Animator animator;
    private Image joystickSickle;


    private void Start()
    {
        joystickSickle = GetComponent<Image>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickSickle.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            animator.SetTrigger("Hit");
        }
    }
}
