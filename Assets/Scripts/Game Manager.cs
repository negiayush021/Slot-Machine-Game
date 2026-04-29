using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public ReelController[] controllers;
    public bool hasEvaluated = true;

    [SerializeField] private TextMeshProUGUI credits_txt;
    [SerializeField] private TextMeshProUGUI Bet_txt;
    float credits_count = 0;
    int bet_count = 0;

    public GameObject Betbtn;
    [SerializeField] private Sprite BetbtnDisableIMG;
    [SerializeField] private Sprite BetbtnNormalIMG;

    [SerializeField] private GameObject CelebrationParticles;

    
    

    private void Update()
    {
        Bet_txt.text = bet_count.ToString();

        if (!hasEvaluated)
        {
            AudioManager.instance.PlayClip(2);
            bool allfinished = true;
            foreach (var controller in controllers)
            {
                if (!controller.spinningfinish)
                {
                    allfinished = false;
                    break;
                }
            }

            if (allfinished)
            {
                hasEvaluated = true;
                CheckWin(controllers[0].index, controllers[1].index, controllers[2].index);
            }
        }

        
    }

    public void CheckWin(int symbol1, int symbol2, int symbol3)
    {
        bool allMatch = (symbol1 == symbol2 && symbol2 == symbol3);
        bool anyTwoMatch = (symbol1 == symbol2) || (symbol2 == symbol3) || (symbol3 == symbol1);

        if (allMatch)
        {
            StartCoroutine(credit_calculate(5));
            StartCoroutine(ShowWinningJackpot());
        }
        else if (anyTwoMatch)
        {
            StartCoroutine(credit_calculate(2));
        }
        else
        {
            // no match
            Debug.Log("No match");
            HandleScript.instance.HandleButton.interactable = true;
            NormalBetBtn();
        }

    }

    IEnumerator credit_calculate(int multiplier)
    {
        AudioManager.instance.PlayClip(3);
        float targetCredits = credits_count + (bet_count * multiplier);
        float duration = 0.5f;
        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            credits_count = Mathf.Lerp(credits_count, targetCredits, elapsed / duration);
            credits_txt.text = Mathf.RoundToInt(credits_count).ToString(); 
            yield return null;
        }

        credits_count = targetCredits; 
        credits_txt.text = Mathf.RoundToInt(credits_count).ToString();
        HandleScript.instance.HandleButton.interactable = true;
        NormalBetBtn();
    }

    IEnumerator ShowWinningJackpot()
    {
        AudioManager.instance.PlayClip(4);
        CelebrationParticles.SetActive(true);
        yield return new WaitForSeconds(3);
        HandleScript.instance.HandleButton.interactable = true;

    }


    public void BetButton()
    {
        AudioManager.instance.PlayClip(0);
        bet_count++;
    }

    public void DisbaleBetBtn()
    {
        Betbtn.GetComponent<Image>().sprite = BetbtnDisableIMG;
        Betbtn.GetComponent<Button>().interactable = false;
        
    }
    public void NormalBetBtn()
    {
        Betbtn.GetComponent<Image>().sprite = BetbtnNormalIMG;
        Betbtn.GetComponent<Button>().interactable = true;
        bet_count = 0;
    }
}
