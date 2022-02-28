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
    
    //  self ui for battle
    public Image selfActionBar;
    public Text selfHealthPoint;
    [SerializeField] private Text selfSkill_1Text;
    [SerializeField] private Text selfSkill_2Text;
    [SerializeField] private Text selfSkill_3Text;
    
    // enemy ui for battle
    public Image enemyActionBar;
    public Text enemyHealthPoint;
    [SerializeField] private Text enemySkill_1Text;
    [SerializeField] private Text enemySkill_2Text;
    [SerializeField] private Text enemySkill_3Text;

    // variable for battle
    private Character self;
    private Character enemy;
    private float selfBattleHp;
    private float selfActionEnergy;
    private float enemyBattleHp;
    private float enemyActionEnergy;
    
    // Start is called before the first frame update
    public void Start(){
        // set up canvas manager
        this._canvasManager = managerObject.GetComponent<CanvasManager>();
        this.battleCanvas.GetComponent<CanvasGroup>().alpha = 1f;

        // set up character
        this.self = UserAccount.getInstance().getUserCharacter();
        this.enemy = new Character(5, 100, 3);
        enemy.setSkill_1(SkillConstant.SKILL_1A);
        enemy.setSkill_2(SkillConstant.SKILL_2A);
        enemy.setSkill_3(SkillConstant.SKILL_3A);
        
        // set up battle variable
        this.selfBattleHp = self.getMaxHp();
        this.selfActionEnergy = 0;
        this.enemyBattleHp = enemy.getMaxHp();
        this.enemyActionEnergy = 0;
        
        // set up skill UI
        this.selfSkill_1Text.text = self.getSkill_1().getSkillName();
        this.selfSkill_2Text.text = self.getSkill_2().getSkillName();
        this.selfSkill_3Text.text = self.getSkill_3().getSkillName();
        this.enemySkill_1Text.text = enemy.getSkill_1().getSkillName();
        this.enemySkill_2Text.text = enemy.getSkill_2().getSkillName();
        this.enemySkill_3Text.text = enemy.getSkill_3().getSkillName();


    }

    private void attackEnemy(){
        // basic attack
        this.enemyBattleHp -= this.self.getBasicAttack();

        // update UI
        this.selfHealthPoint.text =  selfBattleHp.ToString() + " / " + self.getMaxHp().ToString();
        this.enemyHealthPoint.text = enemyBattleHp.ToString() + " / " + enemy.getMaxHp().ToString();
    }

    private void attackByEnemy(){
        // basic attack
        this.selfBattleHp -= enemy.getBasicAttack();

        // update UI
        this.selfHealthPoint.text =  selfBattleHp.ToString() + " / " + self.getMaxHp().ToString();
        this.enemyHealthPoint.text = enemyBattleHp.ToString() + " / " + enemy.getMaxHp().ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (enemyBattleHp < 0)
            endOfBattle();
        
        // if user action energy full, then attack enemy
        if (this.selfActionEnergy >= ACTION_ENERGY_NEED){
            this.attackEnemy();
            selfActionEnergy = 0;
        }
           
        
        // if enemy action energy full, then attack user
        if (this.enemyActionEnergy >= ACTION_ENERGY_NEED){
            this.attackByEnemy();
            enemyActionEnergy = 0;
        }
           
        
        this.selfActionEnergy += this.self.getSpeed() * Time.deltaTime;
        this.enemyActionEnergy += this.enemy.getSpeed() * Time.deltaTime;

        this.selfHealthPoint.text =  selfBattleHp.ToString() + " / " + self.getMaxHp().ToString();

        this.enemyHealthPoint.text = enemyBattleHp.ToString() + " / " + enemy.getMaxHp().ToString();


        this.selfActionBar.fillAmount = (float)(selfActionEnergy / ACTION_ENERGY_NEED);
        this.enemyActionBar.fillAmount = (float)(enemyActionEnergy / ACTION_ENERGY_NEED);
    }

    private void endOfBattle(){
        this.battleCanvas.GetComponent<CanvasGroup>().alpha = 0.2f;
        Time.timeScale = 0f;
        this._canvasManager.setReward();

    }
    

}
