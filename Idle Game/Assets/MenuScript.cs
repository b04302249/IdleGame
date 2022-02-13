using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject managerObject;
    private CanvasManager _canvasManager;

    // Start is called before the first frame update
    public void Start()
    {
        this._canvasManager = managerObject.GetComponent<CanvasManager>();
    }

    public void newGame(){
        UserAccount userAccount = UserAccount.getInstance();
        
        // set some information about account
        UserInfo userInfo = new UserInfo(0, 0, "testUser");
        userAccount.setUserInfo(userInfo);
        
        // set up user character
        Skill skill_1 = new Skill(8, -3);
        Skill skill_2 = new Skill(30, 10);
        Character userChar = new Character(100, 0, 5, skill_1, skill_2);
        userAccount.setUserCharacter(userChar);
        
        this._canvasManager.setPlay();
    }

    public void loadGame()
    {
        string id = "1";
        string url = "http://localhost:8080/user/" + id;
        StartCoroutine(getRequest(url));
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    
    public IEnumerator getRequest(string uri){
        using (UnityWebRequest request = UnityWebRequest.Get(uri)){
            yield return request.SendWebRequest();
            
            switch (request.result){
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError( request.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError( request.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //setUserText(request.downloadHandler.text);
                    break;
            }
        }
    }
}
