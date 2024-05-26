using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;

    int kalanSure;
    bool sureSaysinmi = true;



    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {

        kalanSure = 93;

       sureSaysinmi = true;

    }

    public void SureyiBaslat()
    {

        StartCoroutine(SureTimerRoutine());

    }


    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                SureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                SureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                SureText.text = "";
                gameManager.OyunuBitir();

            }

            kalanSure--;
        }
    }


}

