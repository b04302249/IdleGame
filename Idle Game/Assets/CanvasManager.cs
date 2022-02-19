using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject battleCanvas;
    [SerializeField] private GameObject rewardCanvas;
    
    public void setMenu(){
        menuCanvas.SetActive(true);
        playCanvas.SetActive(false);
        battleCanvas.SetActive(false);
        rewardCanvas.SetActive(false);
    }

    public void setPlay(){
        menuCanvas.SetActive(false);
        playCanvas.SetActive(true);
        battleCanvas.SetActive(false);
        rewardCanvas.SetActive(false);
    }

    public void setBattle(){
        menuCanvas.SetActive(false);
        playCanvas.SetActive(false);
        battleCanvas.SetActive(true);
        rewardCanvas.SetActive(false);
    }

    public void setReward(){
        menuCanvas.SetActive(false);
        playCanvas.SetActive(false);
//        battleCanvas.SetActive(false);
        rewardCanvas.SetActive(true);
    }
    
}
