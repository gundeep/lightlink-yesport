using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeal : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    //playercard animation
    public void DrawPlayerCard()
    {
        animator.SetTrigger("DrawPlayerCard");
    }
    public void DrawDealerCard()
    {
       animator.SetTrigger("DrawDealerCard");
    }
    


}
