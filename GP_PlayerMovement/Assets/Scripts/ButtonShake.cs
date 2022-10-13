using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonShake : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    public void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        anim.enabled = true;
        anim.Play("ButtonShakeAnimation");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //anim.enabled = false;
    }

    
}
