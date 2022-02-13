

public class UserAccount {
    private static UserAccount accountInstance;

    private UserInfo _userInfo;
    private Character _userCharacter;


    public static void CreateInstance()
    {
        if (accountInstance == null){
            accountInstance = new UserAccount();
        }
    }

    public static UserAccount getInstance(){
        if (accountInstance == null){
            CreateInstance();
        }
        return accountInstance;
    }

    public UserInfo getUserInfo(){
        return this._userInfo;
    }

    public void setUserInfo(UserInfo userInfo){
        this._userInfo = userInfo;
    }

	public Character getUserCharacter(){
		return this._userCharacter;
	}
    
	public void setUserCharacter(Character userCharacter){
	    this._userCharacter = userCharacter;
	}

}
