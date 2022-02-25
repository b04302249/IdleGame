using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{
    private float basicAttack;
    private float max_hp;
    private float speed;
    private Skill skill_1;
    private Skill skill_2;
    private Skill skill_3;

    public Character(float atk, float hp, float speed){
        this.basicAttack = atk;
        this.max_hp = hp;
        this.speed = speed;
    }

    public float getSpeed(){
        return this.speed;
    }

    public float getMaxHp(){
        return this.max_hp;
    }

    public float getBasicAttack(){
        return this.basicAttack;
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

    public Skill getSkill_3(){
        return this.skill_3;
    }

    public void setSkill_3(Skill skill){
        this.skill_3 = skill;
    }
}
