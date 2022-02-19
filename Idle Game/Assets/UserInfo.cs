using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo {
    
    private int gems;
    private double meditationPower;
    private string userName;
    private MartialStage martialStage;

    public UserInfo(int gems, int meditationPower, string userName, MartialStage martialStage)
    {
        this.gems = gems;
        this.meditationPower = meditationPower;
        this.userName = userName;
        this.martialStage = martialStage;
    }
    
    
    public int getGems(){
        return this.gems;
    }

    public double getMeditationPower(){
        return this.meditationPower;
    }

    public void meditationPowerAdd(double delta){
        this.meditationPower += delta;
    }

    public void setMeditationPower(double meditationPower){
        this.meditationPower = meditationPower;
    }

    public string getUserName(){
        return this.userName;
    }

    public MartialStage getMartialStage(){
        return this.martialStage;
    }

    public void setMartialStage(MartialStage martialStage){
        this.martialStage = martialStage;
    }
}
