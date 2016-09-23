using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameSetting
{
    GameInit,
    GameStart,
    GamePause,
    GamePlaying,
    GameSet
}

public enum GameStage
{
    Stage1 = 1,
    Stage2,
    Stage3,
    Stage4,
    Stage5
}
public partial class GameManager : MonoBehaviour{

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("cSingleton == null");

            return _instance;
        }
    }
    
    void Awake()
    {
        _instance = this;
    }

    const int StartPosX = 0;
    const int StartPosY = 0;

    public GameObject MainCam;
    public GameObject[] Background;
    public GameObject tile;
    public GameObject Player;
    public GameObject UICam;

    public GameObject[] goTemp = new GameObject[5];
    GameObject mainBackGroundObj;
    public GameSetting gameSetting;
    public GameStage stage;

    GameObject dotBlueTemp; //dotblue를 담는 부모오브젝트
    GameObject dotBlackTemp; //dotblack을 담는 부모오브젝트


    //스코어
    Text BestScore;
    Text CurrentScore;
    Text Level;
    int score;

    Vector2[] dotBluePosition =
    {
        new Vector2(0,0),
        new Vector2(1,0),
        new Vector2(-1,0),
        new Vector2(1,1),
        new Vector2(-1,-1),
        new Vector2(0,1),
        new Vector2(0,-1),
        new Vector2(-1,1),
        new Vector2(1,-1)
    };

    List<int> randomList = new List<int>();
    int dotBluePositionRandom = 0;
    bool playingFirst = false;

    int NextPosition;
    int NextPositionTemp;

    string[] BlackPos = { "UP", "DOWN", "RIGHT", "LEFT" };
    float spawnDelayTime;
    public float SpawnDelayTime
    {
        get
        {
            return spawnDelayTime;
        }
        set
        {
            spawnDelayTime = value;
        }
    }
    void Start ()
    {
        if(gameSetting == GameSetting.GameInit)
            init();
	}
    void init()
    {
        goTemp[0] = Instantiate(Background[0]) as GameObject; //뒷 배경 생성
        mainBackGroundObj = Instantiate(Resources.Load("mainBackground")) as GameObject;
        mainBackGroundObj.transform.SetParent(UICam.transform);
        mainBackGroundObj.transform.localScale = new Vector3(1, 1, 1);
        mainBackGroundObj.transform.localPosition = new Vector3(-10, -1, 0);
        mainBackGroundObj.AddComponent<BtnManager>();
    }
    public void GameLoopingSet(GameSetting gameSetting)
    {
        switch (gameSetting)
        {
            case GameSetting.GameInit:
                init();
                break;
            case GameSetting.GameStart:
                gameStart();
                break;
            case GameSetting.GamePlaying:
                StartCoroutine(gamePlaying());
                break;
            case GameSetting.GameSet:
                gameSet();
                break;
            case GameSetting.GamePause:
                gamePause();
                break;
        }
    }
    private int RandomFunction(int preRandom)
    {
        randomList.Clear();

        for(int i = 0; i < 9; i++)
        {
            randomList.Add(i);
        }
        for(int i = 0; i<randomList.Count; i++)
        {
            if(randomList[i] == preRandom)
            {
                randomList.Remove(i);
            }
        }
        int nextRandom = randomList[Random.Range(0, randomList.Count - 1)];
        return nextRandom;
    }
    private int RandomFunction(int preRandom, int ok)
    {
        List<int> randomBlack = new List<int>();
        randomBlack.Clear();
        randomBlack.Add(-1);
        randomBlack.Add(0);
        randomBlack.Add(1);

        int nextRandom = 0;

        for(int i = 0; i < randomBlack.Count; i++)
        {
            if (preRandom == randomBlack[i])
            {
                if (i + 1 > 2)
                    nextRandom = randomBlack[0];
                else
                    nextRandom = randomBlack[i + 1];
            }
        }
        return nextRandom;
    }
    void gameStart()
    {
        Debug.Log("=====게임 시작=======");
        mainBackGroundObj.SetActive(false);

        GameObject Score = Instantiate(Resources.Load("Score")) as GameObject;
        Score.transform.SetParent(UICam.transform);
        Score.transform.localScale = new Vector3(1, 1, 1);
        Score.transform.localPosition = new Vector3(20, 504, 0);

        BestScore = Score.transform.FindChild("BestScore").GetComponent<Text>();
        CurrentScore = Score.transform.FindChild("CurrentScore").GetComponent<Text>();
        Level = Score.transform.FindChild("Level").GetComponent<Text>();

        GameObject goTemp_tile = Instantiate(tile) as GameObject;
        goTemp_tile.transform.parent = MainCam.transform;
        dotBlueTemp = Instantiate(Resources.Load("dotBlueTemp")) as GameObject;
        dotBlackTemp = Instantiate(Resources.Load("dotBlackTemp")) as GameObject;

        goTemp[0].transform.parent = MainCam.gameObject.transform;
        dotBlueTemp.transform.parent = MainCam.gameObject.transform;
        dotBlackTemp.transform.parent = MainCam.gameObject.transform;

        Player = Instantiate(Player, new Vector2(StartPosX, StartPosY), Quaternion.identity) as GameObject;
        Player.AddComponent<GameController>();

        ObjectPool.DotBlueCapacity = 1;
        ObjectPool.CreateObject("dotBlue", dotBlueTemp);

        ObjectPool.DotBlackCapacity = 10;
        ObjectPool.CreateBlackObject("UPDOWN_Enemy", dotBlackTemp);
        ObjectPool.CreateBlackObject("DOWNUP_Enemy", dotBlackTemp);
        ObjectPool.CreateBlackObject("RIGHTLEFT_Enemy", dotBlackTemp);
        ObjectPool.CreateBlackObject("LEFTRIGHT_Enemy", dotBlackTemp);

        SpawnDelayTime = 1.0f;
       
        playingFirst = true;
        dotBluePositionRandom = RandomFunction(Random.Range(0, 9));

        GameLoopingSet(GameSetting.GamePlaying);
        StartCoroutine(blackSpawn());
    }
    public IEnumerator gamePlaying()
    {
        yield return new WaitForSeconds(0.2f);
        if (playingFirst)
        {
            yield return new WaitForSeconds(0.5f);
            NextPosition = RandomFunction(dotBluePositionRandom);
            score = 0;
            playingFirst = false;
        }
        else
        {
            score += 1;
            NextPosition = RandomFunction(NextPositionTemp);         
        }

        CurrentScore.text = score.ToString();
        if(System.Convert.ToInt32(BestScore.text) <= score)
        {
            BestScore.text = score.ToString();
        }

        if (score == 0)
        {
            stage = GameStage.Stage1;
        }
        if (score == 10)
        {
            stage = GameStage.Stage2;
            goTemp[1] = Instantiate(Background[1]);
            goTemp[1].transform.parent = MainCam.transform;
        }
        if (score == 20)
        {
            stage = GameStage.Stage3;
            goTemp[2] = Instantiate(Background[2]);
            goTemp[2].transform.parent = MainCam.transform;   
        }
        if(score == 30)
        {
            stage = GameStage.Stage4;
            goTemp[3] = Instantiate(Background[3]);
            goTemp[3].transform.parent = MainCam.transform;
        }
        if(score == 40)
        {
            stage = GameStage.Stage5;
            goTemp[4] = Instantiate(Background[4]);
            goTemp[4].transform.parent = MainCam.transform;
        } 

        NextPositionTemp = NextPosition;
       
        ObjectPool.Instantiate("dotBlue", dotBluePosition[NextPosition], Quaternion.identity);
    }

    void gameSet()
    {

    }

    void gamePause()
    {

    }
}
