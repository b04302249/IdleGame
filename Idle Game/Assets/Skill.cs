using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    private float power;
    private float energyNeed;
    private int level;

    public Skill(float power, float energyNeed){
        this.power = power;
        this.energyNeed = energyNeed;
        this.level = 1;
    }

    public void setPower(float p){
        this.power = p;
    }

    public void setEnergyNeed(float en){
        this.energyNeed = en;
    }

    public float getPower(){
        return this.power;
    }

    public float getEnergyNeed(){
        return this.energyNeed;
    }

    public int levelUpCost(){
        return this.level * 2 + 1;
    }

    public int getLevel(){
        return this.level;
    }

    public void levelUp(){
        this.level += 1;
        this.power += 1;
    }

    public string getUpgradeInformation(){
        return "Cost: " + (this.level*2+1) + " coins\nPower: +1" ;
    }

    public string getAbilityInformation(){
        if (this.energyNeed > 0f)
            return "Power:" + this.power + "\nEnergy" + (-this.energyNeed);
        else
            return "Power:" + this.power + "\nEnergy+" + (-this.energyNeed);
    }
}
