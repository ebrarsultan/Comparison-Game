using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject puanSurePaneli;

    [SerializeField]
    public GameObject pausePaneli,sonucPaneli;

    [SerializeField]
    public GameObject PuaniKapYazisi, BuyukOlanSayiSecYazisi;

    [SerializeField]
    public GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    public Text ustText, altText, puanText;


    TimerManager timerManager;
    DairelerMAnager dairelerMAnager;
    TrueFalseManager trueFalseManager;
    SonucManager sonucManager;

    int oyunSayac, kacinciOyun;

    int ustDeger, altDeger;

    int buyukDeger;

    int butonDegeri;

    int toplamPuan, artisPuani;

    int dogruAdet, yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi, bitisSesi;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
        dairelerMAnager = Object.FindObjectOfType<DairelerMAnager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();

        audioSource = GetComponent<AudioSource>();

    }

    void Start()
    {
        toplamPuan = 0;
        oyunSayac = 0;
        kacinciOyun = 0;
        puanText.text = "0";

        SahneEkraniniGuncelle();



    }
    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        PuaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);
        BuyukOlanSayiSecYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);

        OyunaBasla();

    }
    public void OyunaBasla()
    {

        audioSource.PlayOneShot(baslangicSesi);

        Debug.Log("Oyun Ba�lad�");

        timerManager.SureyiBaslat();

        PuaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0, 0.2f);

        KacinciOyun();
    }

    void KacinciOyun()
    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
            artisPuani = 25;
        }
        else if (oyunSayac >= 5 && oyunSayac < 10)
        {
            kacinciOyun = 2;
            artisPuani = 50;
        }
        else if (oyunSayac >= 10 && oyunSayac < 15)
        {
            kacinciOyun = 3;
            artisPuani = 75;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
            artisPuani = 100;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
            artisPuani = 125;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6);
            artisPuani = 150;
        }
        switch (kacinciOyun)

        {
            case 1:
                BirinciFonksiyon();
                break;
            case 2:
                IkinciFonksiyon();
                break;
            case 3:
                UcuncuFonksiyon();
                break;

            case 4:
                DorduncuFonksiyon();
                break;

            case 5:
                BesinciFonksiyon();
                break;

        }
    }

    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(1, 50);

        if (rastgeleDeger <= 25)
        {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 15);
        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 15));
        }

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            BirinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();

        Debug.Log("b�y�k de�er " + buyukDeger);

    }
    void IkinciFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);

        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger = ucuncuSayi + dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            IkinciFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "+" + ikinciSayi;
        altText.text = ucuncuSayi + "+" + dorduncuSayi;

    }
    void UcuncuFonksiyon()
    {
        int birinciSayi = Random.Range(11, 30);
        int ikinciSayi = Random.Range(1, 11);

        int ucuncuSayi = Random.Range(11, 40);
        int dorduncuSayi = Random.Range(1, 11);

        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            UcuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "-" + ikinciSayi;
        altText.text = ucuncuSayi + "-" + dorduncuSayi;

    }

    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 10);

        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 10);

        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            DorduncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " x " + ikinciSayi;
        altText.text = ucuncuSayi + " x " + dorduncuSayi;

    }

    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);

        int bolunen1 = bolen1 * ustDeger;


        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);

        int bolunen2 = bolen2 * altDeger;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            BesinciFonksiyon();
            return;
        }

        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;

    }
    public void ButonDegeriniBelirle(string butonAdi)
    {
        if (butonAdi == "ustButon")
        {
            butonDegeri = ustDeger;
        }
        else if (butonAdi == "altButon")
        {
            butonDegeri = altDeger;
        }

        if (butonDegeri == buyukDeger)
        {

            trueFalseManager.TrueFalseScaleAc(true);

            dairelerMAnager.DaireninScaleAc(oyunSayac % 5);

            oyunSayac++;

            toplamPuan += artisPuani;

            puanText.text = toplamPuan.ToString();

            dogruAdet++;

            KacinciOyun();
        }

        else
        {
            yanlisAdet++;

            trueFalseManager.TrueFalseScaleAc(false);
            HatayaGoreSayaciAzalt();
            KacinciOyun();
        }
    }
    void HatayaGoreSayaciAzalt()
    {
        oyunSayac -= (oyunSayac % 5 + 5);

        if (oyunSayac < 0)
        {
            oyunSayac = 0;
        }


        dairelerMAnager.DairelerinScaleKapat();
    }

    public void PausePaneliniAc()
    {
        pausePaneli.SetActive(true);
    }


    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisSesi);

        sonucPaneli.SetActive(true);


        sonucManager = Object.FindObjectOfType<SonucManager>();


        sonucManager.SonuclariGoster(dogruAdet, yanlisAdet, toplamPuan);


    }


}

