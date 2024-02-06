using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private List<int> playerCards = new List<int>();
    private List<int> dealerCards = new List<int>();
    public Text dialogueText;
    public Text playerScore;
    public Text dealerScoreText;
    public Text winsRecordText;
    public Text lastCard;
    public CardDeal cardDeal;
    public CardIAC cardScript;
    public UIManager UIManager;
    public GameObject pCardRef;
    public GameObject dCardRef;
    private float cardNumberingSpacing = 0; //spaces out cards diagonally with each additional card
    private float dealerCardNumberSpacing;
    private int currentScore;
    private int dealerScore;
    private int winsRecord=0;

    private List<int> cardDeck = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12,13,
                     1,2,3,4,5,6,7,8,9,10,11,12,13,
                     1,2,3,4,5,6,7,8,9,10,11,12,13,
                     1,2,3,4,5,6,7,8,9,10,11,12,13}; 

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    void updateWinsRecord()
    {
        winsRecordText.text = "Wins record: " + winsRecord;
    }


    void gameover()
    {
        UIManager.buttonsInteract(false);
        if (currentScore == 21) //player draws 21
        {
            dialogueText.text = "You drew a 21, you win! one point added to wins record";
            winsRecord++;
        }
        if (currentScore>21)//player score over 21
        {
            dialogueText.text = "Bust! You went over 21, you lose hahahaha! one point deducted from wins record";
            winsRecord--;
        }
        if (currentScore<dealerScore && dealerScore<22) //dealer score more and is not over 21
        {
            dialogueText.text = "Dealer wins. one point deducted from wins record";
            winsRecord--;
        }
        if (currentScore>dealerScore && currentScore<22)//p score more  and not over 21
        {
            dialogueText.text = "You win! one point added to wins record";
            winsRecord++;
        }
        if (currentScore==dealerScore)//tie
        {
            dialogueText.text = "You and the dealer both tied. Nothing happens...";
        }
        if (dealerScore>21)//dbust
        {
            dialogueText.text = "Dealer bust! one point added to wins record";
            winsRecord++;
        }
        updateWinsRecord();
        UIManager.toggleResetButton();
    }
    
    public void resetGame()
    {
        cardScript.executeOrder66();
        StartGame();
        cardNumberingSpacing = 0;
        dealerCardNumberSpacing = 0;
    }

    public IEnumerator Stand()
    {
        
        UIManager.buttonsInteract(false);

        while(dealerScore<17)
        {
            StartCoroutine(DealerDraw());
            yield return new WaitForSeconds(1f); //time to wait for card dealing anim to finish
        }
        gameover();
    }

    
    public void StartGame()
    {
        dealerScore = 0;
        currentScore = 0;
        
        StartCoroutine(DealerDraw());
        
        //reset cardDeck
        cardDeck = new List<int> {1,2,3,4,5,6,7,8,9,10,10,10,10,
                     1,2,3,4,5,6,7,8,9,10,10,10,10,
                     1,2,3,4,5,6,7,8,9,10,10,10,10,
                     1,2,3,4,5,6,7,8,9,10,10,10,10};
        cardDeal.DrawDealerCard();
        //deals two cards
        StartCoroutine(dealCard());
        StartCoroutine(dealCard());
        //StartCoroutine(dealCard());

        dialogueText.text = "Would you like to hit, or stand?";

        UIManager.buttonsInteract(true);
    }

    
    public IEnumerator dealCard()
    {
        int cardIndex;
        cardIndex = UnityEngine.Random.Range(1, cardDeck.Count-1);
        cardDeal.DrawPlayerCard();
        yield return new WaitForSeconds(0.7f); //time to wait for card dealing anim to finish

        playerCards.Add(cardDeck[cardIndex]);
        cardScript.PlaceCard(cardDeck[cardIndex], pCardRef.transform.position.x + (cardNumberingSpacing * 60), pCardRef.transform.position.y - (cardNumberingSpacing * 45));
        
        //updates last card text box and total card score
        lastCard.text = "Last Card: " + cardDeck[cardIndex].ToString();
        currentScore += cardDeck[cardIndex];
        playerScore.text = "Total: " + (currentScore).ToString();

        cardNumberingSpacing+=1;

        //cardDeck.RemoveAt(cardIndex); causing problems, think it has to do with the coroutine running before it. maybe fix later.

        if (currentScore > 21)
        {
            gameover();
        }
        if (currentScore == 21)
        {
            gameover();
        }
        
    }
    public IEnumerator DealerDraw()
    {
        int cardIndex;
        cardIndex = UnityEngine.Random.Range(1, cardDeck.Count);
        cardDeal.DrawDealerCard();//anim
        yield return new WaitForSeconds(0.7f); //time to wait for card dealing anim to finish

        dealerCards.Add(cardDeck[cardIndex]);
        cardScript.PlaceCard(cardDeck[cardIndex], dCardRef.transform.position.x + (dealerCardNumberSpacing * 30), dCardRef.transform.position.y - (dealerCardNumberSpacing * 30));

        
        dealerScore += cardDeck[cardIndex];
        dealerScoreText.text = "Total: " + (dealerScore).ToString();

        dealerCardNumberSpacing++;
        cardDeck.RemoveAt(cardIndex);

        
    }
}
