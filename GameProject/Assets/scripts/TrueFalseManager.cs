using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;
    void Start()
    {
        ScaleDegeriniKapat();
    }

    public void TrueFalseScaleAc(bool dogrumuYanlismi)
    {
        if (dogrumuYanlismi)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

        Invoke("ScaleDegeriniKapat", 0.4f);
    }
    void ScaleDegeriniKapat()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

}
