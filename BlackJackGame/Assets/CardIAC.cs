using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardIAC : MonoBehaviour
{
    public Transform prefab;
    public Text topLeftNumber;
    public Text bottomRightNumber;
    public Text middleNumber;
    public GameObject frame;
    public GameObject cardPile;
    private Color red = new Color32(192, 34, 34,255);
    private Color black = new Color32(0, 0, 0, 255);
    public Canvas canvas;

    private void Start()
    {
        
    }
    public void PlaceCard(int number, float x, float y)
    {

        topLeftNumber.text = number.ToString();
        bottomRightNumber.text = number.ToString();
        middleNumber.text = number.ToString();
        
        int i = Random.Range(1, 3);
        if (i == 1)
        {

            topLeftNumber.GetComponent<Text>().color = black;
            bottomRightNumber.GetComponent<Text>().color = black;
            middleNumber.GetComponent<Text>().color = black;
            frame.GetComponent<Image>().color = black;
        }
        if (i == 2)
        {

            topLeftNumber.GetComponent<Text>().color = red;
            bottomRightNumber.GetComponent<Text>().color = red;
            middleNumber.GetComponent<Text>().color = red;
            frame.GetComponent<Image>().color = red;
        }


        Transform card = (Transform)Instantiate(prefab, new Vector2(x,y), Quaternion.identity);
        
        card.transform.SetParent(GameObject.Find("UI Canvas").transform);
        card.transform.localScale = new Vector2(.17f, .17f);
        card.transform.position = new Vector2(x,y);

    }

    public void executeOrder66()
    {
        var clones = GameObject.FindGameObjectsWithTag("card");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
}
