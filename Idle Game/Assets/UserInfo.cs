using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo {
    
    private int gems;
    private int coins;
    private string userName;

    public UserInfo(int gems, int coins, string userName)
    {
        this.gems = gems;
        this.coins = coins;
        this.userName = userName;
    }
    
    
    public int getGems(){
        return this.gems;
    }

    public int getCoins(){
        return this.coins;
    }

    public string getUserName(){
        return this.userName;
    }
}
