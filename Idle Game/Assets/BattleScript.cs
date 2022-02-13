using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScript : MonoBehaviour
{
    public static float ACTION_ENERGY_NEED = 4;
    
    // canvas manager
    public GameObject managerObject;
    private CanvasManager _canvasManager;
    [SerializeField] private GameObject battleCanvas;
    
    // ui for battle
    public Image selfActionBar;
    public Image enemyActionBar;
    public Text selfHealthPoint;
    public Text selfEnergy;
    [SerializeField] private Text selfSkill_1Text;
    [SerializeField] private Text selfSkill_2Text;
    public Text enemyHealthPoint;
    public Text enemyEnergy;
    
    
    private Character self;
    private Character enemy;
    private float selfActionEnergy;
    private float enemyActionEnergy;
    
    // Start is called before the first frame update
    public void Start(){
        // set up canvas manager
        this._canvasManager = managerObject.GetComponent<CanvasManager>();
        
        // set up battle
        this.selfActionEnergy = 0;
        this.enemyActionEnergy = 0;
        UserAccount userAccount = UserAccount.getInstance();
        this.battleCanvas.GetComponent<CanvasGroup>().alpha = 1f;
        
        // refresh skill ability
        selfSkill_1Text.text = userAccount.getUserCharacter().getSkill_1().getAbilityInformation();
        selfSkill_2Text.text = userAccount.getUserCharacter().getSkill_2().getAbilityInformation();

        // hard code character here
        Skill skill_1 = new Skill(8, -3);
        Skill skill_2 = new Skill(30, 10);

        this.self = userAccount.getUserCharacter();
        this.enemy = new Character(100, 0, 3, skill_1, skill_2);
    }

    public void useSkill_1(){
        // if actionEnergy is not enough, then skill can not trigger
        if (this.selfActionEnergy < ACTION_ENERGY_NEED)
            return;
        this.self.useSkill_1(enemy);
        this.selfActionEnergy = 0;
    }

    public void useSkill_2(){
        if (this.selfActionEnergy < ACTION_ENERGY_NEED)
            return;
        this.self.useSkill_2(enemy);
        this.selfActionEnergy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.getHealthPoint() < 0)
            endOfBattle();
        if (this.selfActionEnergy >= ACTION_ENERGY_NEED)
            return;
        this.selfActionEnergy += this.self.getSpeed() * Time.deltaTime;
        this.enemyActionEnergy += this.enemy.getSpeed() * Time.deltaTime;

        this.selfHealthPoint.text =  self.getHealthPoint().ToString() + " / " + self.getMaxHp().ToString();
        this.selfEnergy.text = self.getEnergy().ToString() + " / 50";
        this.enemyHealthPoint.text = enemy.getHealthPoint().ToString() + " / " + enemy.getMaxHp().ToString();
        this.enemyEnergy.text = enemy.getEnergy().ToString() + " / 50";

        this.selfActionBar.fillAmount = (float)(selfActionEnergy / ACTION_ENERGY_NEED);
        this.enemyActionBar.fillAmount = (float)(enemyActionEnergy / ACTION_ENERGY_NEED);
    }

    private void endOfBattle(){
        this.battleCanvas.GetComponent<CanvasGroup>().alpha = 0.2f;
        this._canvasManager.setReward();

    }
    

}
