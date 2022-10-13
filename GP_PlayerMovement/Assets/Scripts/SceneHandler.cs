using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneHandler : MonoBehaviour
{
    private Animator animator;
    private GameObject redGuy;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        redGuy = GameObject.Find("RedGuy");
        animator = redGuy.GetComponent<Animator>();
    }
    public void OnNextBtnClick()
    {
        animator.SetBool("StartRunning", true);
    }
    
}
