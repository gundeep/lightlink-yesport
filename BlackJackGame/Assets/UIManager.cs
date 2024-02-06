using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator StartMenuanimator;
    public Animator SettingsMenu;
    public Animator GameMenu;
    public Animator resetButton;
    public GameManager gamemanager;
    private Animator UIAnimator;
    public Slider slider;
    public Text creditText;


    private void Start()
    {
        UIAnimator = GetComponent<Animator>();
    }
    public void CloseStartTab()
    {
        StartMenuanimator.SetTrigger("CloseStartTab");
        
    }
    public void DealCardOnHit()
    {
        StartCoroutine(gamemanager.dealCard());
    }
    public void standCall()
    {
        StartCoroutine(gamemanager.Stand());
    }
    public void buttonsInteract(bool interact)
    {
        UIAnimator.SetBool("ButtonsActive", interact);
    }

    
    public void changeSlider()
    {
        creditText.fontSize = (int) slider.value;
    }
    

    public void settingsMenu()
    {
        
        SettingsMenu.SetBool("SettingsShowing", ! SettingsMenu.GetBool("SettingsShowing"));
        
        
        
    }

    public void gameMenu()
    {
        GameMenu.SetBool("gamemenu", !GameMenu.GetBool("gamemenu"));
    }
    public void resetButtonPress()
    {
        gamemanager.resetGame();
        toggleResetButton();
    }

    public void toggleResetButton()
    {

        resetButton.SetBool("resetbuttonactive", !resetButton.GetBool("resetbuttonactive"));
    }
    
}
