using UnityEngine;
using System.Collections;

public partial class GameManager : MonoBehaviour
{
    IEnumerator blackSpawn() //스테이지 1단계
    {
        yield return new WaitForSeconds(SpawnDelayTime);
        switch (stage)
        {
            case GameStage.Stage1:
                Level.text = "Level 1";
                Enemy.speed = 2;
                string blackPos = BlackPos[Random.Range(0, 4)];
                switch (blackPos)
                {
                    case "UP":
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(Random.Range(-1, 2), -5), Quaternion.identity);
                        break;
                    case "DOWN":
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(Random.Range(-1, 2), 5), Quaternion.identity);
                        break;
                    case "RIGHT":
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, Random.Range(-1, 2)), Quaternion.identity);
                        break;
                    case "LEFT":
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, Random.Range(-1, 2)), Quaternion.identity);
                        break;
                }
                break;
            case GameStage.Stage2:
                Level.text = "Level 2";
                Enemy.speed = 2;
                string blackPos2 = BlackPos[Random.Range(0, 4)];
                int random = Random.Range(-1, 2);
                int random2 = RandomFunction(random, 0);

                switch (blackPos2)
                {
                    case "UP":
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random, -5), Quaternion.identity);
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random2, -5), Quaternion.identity);
                        break;
                    case "DOWN":
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random, 5), Quaternion.identity);
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random2, 5), Quaternion.identity);
                        break;
                    case "RIGHT":
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random), Quaternion.identity);
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random2), Quaternion.identity);
                        break;
                    case "LEFT":
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random), Quaternion.identity);
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random2), Quaternion.identity);
                        break;
                }
                break;
            case GameStage.Stage3:
                Level.text = "Level 3";
                break;
            case GameStage.Stage4:
                break;
            case GameStage.Stage5:
                break;
        }
        StartCoroutine(blackSpawn());
    }
}
