using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruAdetTxt, yanlisAdetTxt, puanTxt;

    int puanSure = 10;
    bool SureBittimi = true;

    int toplamPuan, YazdirilacakPuan, artisPuan;

    private void Awake()
    {
        SureBittimi = true;
    }


    public void SonuclariGoster(int dogruAdet, int yanlisAdet, int puan)
    {

        dogruAdetTxt.text = dogruAdet.ToString();

        yanlisAdetTxt.text = yanlisAdet.ToString();

        puanTxt.text = puan.ToString();

        toplamPuan = puan;
        artisPuan = toplamPuan / 10;

        StartCoroutine(PuaniYazdirRoutine());
    }

    IEnumerator PuaniYazdirRoutine()
    {

        while (SureBittimi)
        {
            yield return new WaitForSeconds(0.11f);

            YazdirilacakPuan += artisPuan;

            if (YazdirilacakPuan >= toplamPuan)
            {

                YazdirilacakPuan = toplamPuan;

            }

            puanTxt.text = YazdirilacakPuan.ToString();

            if (puanSure <= 0)
            {

                SureBittimi = false;

            }
            puanSure--;
        }

    }

    public void AnaMenuyeDon()
    {

        SceneManager.LoadScene  ("SampleScene");


    }
    public void TekrarOyna()
    {

        SceneManager.LoadScene("GameLevel");

    }


}
