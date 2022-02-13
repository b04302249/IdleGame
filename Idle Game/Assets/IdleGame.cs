using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class IdleGame : MonoBehaviour
{
    
    // ui for play canvas
    public Text coinsText;
    [SerializeField] private Text skill1UpgradeText;
    [SerializeField] private Text skill2UpgradeText;
    [SerializeField] private Text skill1EffectText;
    [SerializeField] private Text skill2EffectText;
    public Text coinPerSecondText;
    public Text accumulateText;

    // variable in play canvas
    private double coinsPerSecond;
    private double coins;
    private double accumulate;
    

    private UserAccount _userAccount = UserAccount.getInstance();
    
    // Start is called before the first frame update
    public void Start(){
        this.coinsPerSecond = 5;
        this.coins = 0;
        this.accumulate = 0;
        Skill skill_1 = _userAccount.getUserCharacter().getSkill_1();
        skill1UpgradeText.text = "Upgrade Skill-1\n" + skill_1.getUpgradeInformation();
        skill1EffectText.text = skill_1.getAbilityInformation();
        Skill skill_2 = _userAccount.getUserCharacter().getSkill_2();
        skill2UpgradeText.text = "Upgrade Skill-2\n" + skill_2.getUpgradeInformation();
        skill2EffectText.text = skill_2.getAbilityInformation();
    }

    public void upgradeSkill_1(){
        Skill skill_1 = _userAccount.getUserCharacter().getSkill_1();
        
        // check if coins is enough or not 
        if (skill_1.levelUpCost() > this.coins)
            return;

        this.coins -= skill_1.levelUpCost();
        skill_1.levelUp();
        skill1UpgradeText.text = "Upgrade Skill-1\n" + skill_1.getUpgradeInformation();
        skill1EffectText.text = skill_1.getAbilityInformation();
    }
    
    public void upgradeSkill_2(){
        Skill skill_2 = _userAccount.getUserCharacter().getSkill_2();
        
        // check if coins is enough or not 
        if (skill_2.levelUpCost() > this.coins)
            return;
        
        this.coins -= skill_2.levelUpCost();
        skill_2.levelUp();
        skill2UpgradeText.text = "Upgrade Skill-2\n" + skill_2.getUpgradeInformation();
        skill2EffectText.text = skill_2.getAbilityInformation();
    }

    public void collect(){
        this.coins += this.accumulate;
        this.accumulate = 0;
    }

    public void testFunction(){
        //StartCoroutine(getRequest("http://localhost:8080/user/all"));

    }
    

    // Update is called once per frame
    public void Update(){
        // TODO: change accumulate into  compute the difference of current time and last collect time
        this.accumulate += Time.deltaTime * coinsPerSecond;
        
        
        // update text
        this.coinsText.text = ((int) coins).ToString() + " Coins";
        this.coinPerSecondText.text = ((int) coinsPerSecond).ToString() + " coin/sec";
        this.accumulateText.text = ((int) accumulate).ToString();

    }
}
