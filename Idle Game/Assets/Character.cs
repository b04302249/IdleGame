using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private float max_hp;
    private float healthPoint;
    private float energyPoint;
    private float speed;
    private Skill skill_1;
    private Skill skill_2;

    public Character(float hp, float energy, float speed, Skill skill_1, Skill skill_2){
        this.max_hp = hp;
        this.healthPoint = hp;
        this.energyPoint = energy;
        this.speed = speed;
        this.skill_1 = skill_1;
        this.skill_2 = skill_2;
    }

    public void useSkill_1(Character opponent){
        useSkill(opponent, skill_1);
    }

    public void useSkill_2(Character opponent){
        useSkill(opponent, skill_2);
    }

    private void useSkill(Character opponent, Skill skill){
        // check if energy is enough to use skill
        if (skill.getEnergyNeed() > energyPoint)
            return;

        // consume energy
        this.energyPoint -= skill.getEnergyNeed();
        
        // attack
        opponent.attackedBy(skill);
    }

    public void attackedBy(Skill skill){
        this.healthPoint -= skill.getPower();
    }

    public float getSpeed(){
        return this.speed;
    }

    public float getHealthPoint(){
        return this.healthPoint;
    }

    public float getMaxHp(){
        return this.max_hp;
    }

    public float getEnergy(){
        return this.energyPoint;
    }

    public Skill getSkill_1(){
        return this.skill_1;
    }

    public void setSkill_1(Skill skill){
        this.skill_1 = skill;
    }

    public Skill getSkill_2(){
        return this.skill_2;
    }

    public void setSkill_2(Skill skill){
        this.skill_2 = skill;
    }
}
