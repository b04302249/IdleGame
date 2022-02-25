using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject battleCanvas;
    [SerializeField] private GameObject rewardCanvas;
    [SerializeField] private GameObject skillCanvas;
    
    public void setMenu(){
        setAllFalse();
        menuCanvas.SetActive(true);
    }

    public void setPlay(){
        setAllFalse();
        playCanvas.SetActive(true);
    }

    public void setBattle(){
        setAllFalse();
        battleCanvas.SetActive(true);
    }

    public void setReward(){
        setAllFalse();
        battleCanvas.SetActive(true);
        rewardCanvas.SetActive(true);
    }

    public void setSkill(){
        setAllFalse();
        skillCanvas.SetActive(true);
    }
    
    private void setAllFalse(){
        menuCanvas.SetActive(false);
        playCanvas.SetActive(false);
        battleCanvas.SetActive(false);
        rewardCanvas.SetActive(false);
        skillCanvas.SetActive(false);
    }
    
}
