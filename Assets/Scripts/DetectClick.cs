using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClick : MonoBehaviour
{

    public RememberCards cardGrid;

    void Start()
    {
        cardGrid = GameObject.Find("CardGrid").GetComponent<RememberCards>();
    }

    public void CardClicked()
    {
        GameObject back = this.transform.Find("back").gameObject;
        back.SetActive(false);

        cardGrid.makeGuess(this.gameObject);
    }
}
