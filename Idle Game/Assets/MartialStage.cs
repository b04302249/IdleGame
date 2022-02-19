



using System.Collections.Generic;
using System.Linq;

public class MartialStage{

    private double mpPerSec;
    private double nextStageCost;
    private string currentStageText;
    private MartialStage nextStage;

    private static List<MartialStage> martialStageList = new List<MartialStage>();

    public static MartialStage LASTSTAGE;

    public static MartialStage getStage(int n){
        return martialStageList[n];
    }

    public static MartialStage getStage(string s){
        return martialStageList.Find(m => m.currentStageText.Equals(s));
    }

    public static void initialMartialList(){
        // create stage list if not create yet
        if (martialStageList == null || !martialStageList.Any()){
            createStageList();
        }
    }
    
    private static void createStageList(){
        LASTSTAGE = new MartialStage(){
            mpPerSec = 0,
            nextStageCost = 20000,
            currentStageText = "Last Stage",
            nextStage = null
        };
        
        MartialStage m5 = new MartialStage{
            mpPerSec = 560,
            nextStageCost = 1600,
            currentStageText = "stage 5",
            nextStage = LASTSTAGE
        };

        MartialStage m4 = new MartialStage{
            mpPerSec = 280,
            nextStageCost = 800,
            currentStageText = "stage 4",
            nextStage = m5
        };

        MartialStage m3 = new MartialStage{
            mpPerSec = 140,
            nextStageCost = 400,
            currentStageText = "stage 3",
            nextStage = m4
        };

        MartialStage m2 = new MartialStage{
            mpPerSec = 70,
            nextStageCost = 200,
            currentStageText = "stage 2",
            nextStage = m3
        };

        MartialStage m1 = new MartialStage{
            mpPerSec = 50,
            nextStageCost = 100,
            currentStageText = "stage 1",
            nextStage = m2
        };
        
        martialStageList.Add(m1);
        martialStageList.Add(m2);
        martialStageList.Add(m3);
        martialStageList.Add(m4);
        martialStageList.Add(m5);
    }
    
    public double getMpPerSec(){
        return this.mpPerSec;
    }

    public void setMpPerSec(double mpPerSec){
        this.mpPerSec = mpPerSec;
    }

    public double getNextStageCost(){
        return this.nextStageCost;
    }

    public void setNextStageCost(double nextStageCost){
        this.nextStageCost = nextStageCost;
    }

    public string getCurrentStageText(){
        return this.currentStageText;
    }

    public void setCurrentStageText(string currentStageText){
        this.currentStageText = currentStageText;
    }

    public MartialStage getNextStage(){
        return this.nextStage;
    }

    public void setNextStageText(MartialStage nextStage){
        this.nextStage = nextStage;
    }
}