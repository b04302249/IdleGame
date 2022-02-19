using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayScript : MonoBehaviour
{
    
    // ui for play canvas
    public Text mpText;
    [SerializeField] private Text skill1UpgradeText;
    [SerializeField] private Text skill2UpgradeText;
    [SerializeField] private Text skill1EffectText;
    [SerializeField] private Text skill2EffectText;
    public Text MPPerSecondText;
    public Text accumulateText;
    public Text MartialCurrentStageText;
    public Text MartialNextStageText;
    public Text MPRequiredNextText;

    // variable in play canvas
    private UserInfo userInfo;


    private UserAccount _userAccount = UserAccount.getInstance();
    
    // Start is called before the first frame update
    public void Start(){
        // set up basic userInfo
        this.userInfo = _userAccount.getUserInfo();

        // set up skill information
        Skill skill_1 = _userAccount.getUserCharacter().getSkill_1();
        skill1UpgradeText.text = "Upgrade Skill-1\n" + skill_1.getUpgradeInformation();
        skill1EffectText.text = skill_1.getAbilityInformation();
        Skill skill_2 = _userAccount.getUserCharacter().getSkill_2();
        skill2UpgradeText.text = "Upgrade Skill-2\n" + skill_2.getUpgradeInformation();
        skill2EffectText.text = skill_2.getAbilityInformation();
        
        // set up martial stage information
        MartialStage stage = userInfo.getMartialStage();
        MartialCurrentStageText.text = stage.getCurrentStageText();
        MartialNextStageText.text = stage.getNextStage().getCurrentStageText();
        MPPerSecondText.text = stage.getMpPerSec().ToString();
        MPRequiredNextText.text = stage.getNextStageCost().ToString();
        
    }

    public void upgradeSkill_1(){
        Skill skill_1 = _userAccount.getUserCharacter().getSkill_1();
        
        // check if coins is enough or not 
        if (skill_1.levelUpCost() > userInfo.getMeditationPower())
            return;

        userInfo.meditationPowerAdd(-skill_1.levelUpCost());
        skill_1.levelUp();
        skill1UpgradeText.text = "Upgrade Skill-1\n" + skill_1.getUpgradeInformation();
        skill1EffectText.text = skill_1.getAbilityInformation();
    }
    
    public void upgradeSkill_2(){
        Skill skill_2 = _userAccount.getUserCharacter().getSkill_2();
        
        // check if coins is enough or not 
        if (skill_2.levelUpCost() > userInfo.getMeditationPower())
            return;
        
        userInfo.meditationPowerAdd(-skill_2.levelUpCost());
        skill_2.levelUp();
        skill2UpgradeText.text = "Upgrade Skill-2\n" + skill_2.getUpgradeInformation();
        skill2EffectText.text = skill_2.getAbilityInformation();
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
