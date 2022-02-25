using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill{
    private float skillCost;
    private SkillType skillType;
    private string skillName;
    private SkillRarity skillRarity;
    private float triggerChance;
    private float effect;


    public Skill(float cost, SkillType type, string name, SkillRarity rarity, float chance, float effect){
        this.skillCost = cost;
        this.skillType = type;
        this.skillName = name;
        this.skillRarity = rarity;
        this.triggerChance = chance;
        this.effect = effect;
    }

    public float getEffect(){
        return this.effect;
    }

    public enum SkillRarity{
        COMMON,
        UN_COMMON,
        RARE,
        EPIC
    }
    
    public enum SkillType{
        NONE,
        SKILL_1,
        SKILL_2,
        SKILL_3
    }

}


