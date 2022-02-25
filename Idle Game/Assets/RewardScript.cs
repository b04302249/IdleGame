using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour{
    
    // canvas manager
    public GameObject managerObject;
    private CanvasManager _canvasManager;
    
    [SerializeField] private GameObject backToPlayButton;
    
    // Start is called before the first frame update
    void Start()
    {
        this._canvasManager = managerObject.GetComponent<CanvasManager>();
    }

    public void backToPlay(){
        this._canvasManager.setPlay();
        Time.timeScale = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
