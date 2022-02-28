using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayScript : MonoBehaviour
{
    
    // ui for play canvas
    [SerializeField] private Text mpText;
    [SerializeField] private Text MPPerSecondText;
    [SerializeField] private Text accumulateText;
    [SerializeField] private Text MartialCurrentStageText;
    [SerializeField] private Text MartialNextStageText;
    [SerializeField] private Text MPRequiredNextText;

    // variable in play canvas
    private UserInfo userInfo;


    private UserAccount _userAccount = UserAccount.getInstance();
    
    // Start is called before the first frame update
    public void Start(){
        // set up basic userInfo
        this.userInfo = _userAccount.getUserInfo();

        // set up skill information

        
        // set up martial stage information
        MartialStage stage = userInfo.getMartialStage();
        MartialCurrentStageText.text = stage.getCurrentStageText();
        MartialNextStageText.text = stage.getNextStage().getCurrentStageText();
        MPPerSecondText.text = stage.getMpPerSec().ToString();
        MPRequiredNextText.text = stage.getNextStageCost().ToString();
        
    }
    

    public void evolve(){
        MartialStage currentStage = userInfo.getMartialStage();
        if (currentStage.getNextStageCost() > userInfo.getMeditationPower()){
            return;
        }

        if (currentStage.getNextStage() == MartialStage.LASTSTAGE){
            return;
        }

        MartialStage evolveStage = currentStage.getNextStage();
        
        userInfo.meditationPowerAdd(-currentStage.getNextStageCost());
        userInfo.setMartialStage(evolveStage);
        MartialCurrentStageText.text = evolveStage.getCurrentStageText();
        MartialNextStageText.text = evolveStage.getNextStage().getCurrentStageText();
        MPPerSecondText.text = evolveStage.getMpPerSec().ToString();
        MPRequiredNextText.text = evolveStage.getNextStageCost().ToString();
    }

    public void testFunction(){
        //StartCoroutine(getRequest("http://localhost:8080/user/all"));

    }


    // Update is called once per frame
    public void Update(){
        // TODO: change accumulate into  compute the difference of current time and last collect time
        userInfo.meditationPowerAdd(Time.deltaTime * userInfo.getMartialStage().getMpPerSec());

        
        
        // update text
        this.accumulateText.text = ((int) userInfo.getMeditationPower()).ToString();
    }
}
