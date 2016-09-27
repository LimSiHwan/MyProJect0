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
                Enemy.speed = 2;
                string blackPos1 = BlackPos[Random.Range(0, 4)];
                int random = Random.Range(-1, 2);
                int random2 = RandomFunction(random, 0);

                switch (blackPos1)
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
                Enemy.speed = 2;

                string blackPos2 = BlackPos[Random.Range(0, 4)];
                int random3 = Random.Range(-1, 2);
                int random4 = RandomFunction(random3, 0);
                SpawnDelayTime = 0.8f;

                switch (blackPos2)
                {
                    case "UP":
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random3, -5), Quaternion.identity);
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random4, -5), Quaternion.identity);
                        break;
                    case "DOWN":
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random3, 5), Quaternion.identity);
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random4, 5), Quaternion.identity);
                        break;
                    case "RIGHT":
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random3), Quaternion.identity);
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random4), Quaternion.identity);
                        break;
                    case "LEFT":
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random3), Quaternion.identity);
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random4), Quaternion.identity);
                        break;
                }
                break;
            case GameStage.Stage4:
                Enemy.speed = 2f;

                string blackPos3 = BlackPos[Random.Range(0, 8)];
                int random5 = Random.Range(-1, 2);
                int random6 = RandomFunction(random5, 0);
                switch (blackPos3)
                {
                    case "UP":
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random5, -5), Quaternion.identity);
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random6, -5), Quaternion.identity);
                        break;
                    case "DOWN":
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random5, 5), Quaternion.identity);
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random6, 5), Quaternion.identity);
                        break;
                    case "RIGHT":
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random5), Quaternion.identity);
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random6), Quaternion.identity);
                        break;
                    case "LEFT":
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random5), Quaternion.identity);
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random6), Quaternion.identity);
                        break;
                    case "RIGHTUP":
                        ObjectPool.Instantiate("RIGHTUP_Enemy", new Vector2(Random.Range(4, 6), Random.Range(4, 6)), Quaternion.identity);
                        break;
                    case "LEFTUP":
                        ObjectPool.Instantiate("LEFTUP_Enemy", new Vector2(Random.Range(-5, -3), Random.Range(4, 6)), Quaternion.identity);
                        break;
                    case "LEFTDOWN":
                        ObjectPool.Instantiate("LEFTDOWN_Enemy", new Vector2(Random.Range(-5, -3), Random.Range(-5, -3)), Quaternion.identity);
                        break;
                    case "RIGHTDOWN":
                        ObjectPool.Instantiate("RIGHTDOWN_Enemy", new Vector2(Random.Range(4, 6), Random.Range(-5, -3)), Quaternion.identity);
                        break;
                }

                break;
            case GameStage.Stage5:
                Enemy.speed = 2f;
                string blackPos4 = BlackPos[Random.Range(0, 8)];
                int random7 = Random.Range(-1, 2);
                int random8 = RandomFunction(random7, 0);
                
                switch (blackPos4)
                {
                    case "UP":
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random7, -5), Quaternion.identity);
                        ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(random8, -5), Quaternion.identity);
                        break;
                    case "DOWN":
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random7, 5), Quaternion.identity);
                        ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(random8, 5), Quaternion.identity);
                        break;
                    case "RIGHT":
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random7), Quaternion.identity);
                        ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(5, random8), Quaternion.identity);
                        break;
                    case "LEFT":
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random7), Quaternion.identity);
                        ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-5, random8), Quaternion.identity);
                        break;
                    case "RIGHTUP":
                        ObjectPool.Instantiate("RIGHTUP_Enemy", new Vector2(Random.Range(4, 6), Random.Range(4, 6)), Quaternion.identity);
                        ObjectPool.Instantiate("RIGHTUP_Enemy", new Vector2(Random.Range(4, 6), Random.Range(4, 6)), Quaternion.identity);
                        break;
                    case "LEFTUP":
                        ObjectPool.Instantiate("LEFTUP_Enemy", new Vector2(Random.Range(-5, -3), Random.Range(4, 6)), Quaternion.identity);
                        ObjectPool.Instantiate("LEFTUP_Enemy", new Vector2(Random.Range(-5, -3), Random.Range(4, 6)), Quaternion.identity);
                        break;
                    case "LEFTDOWN":
                        ObjectPool.Instantiate("LEFTDOWN_Enemy", new Vector2(Random.Range(-5, -3), Random.Range(-5, -3)), Quaternion.identity);
                        ObjectPool.Instantiate("LEFTDOWN_Enemy", new Vector2(Random.Range(-5, -3), Random.Range(-5, -3)), Quaternion.identity);
                        break;
                    case "RIGHTDOWN":
                        ObjectPool.Instantiate("RIGHTDOWN_Enemy", new Vector2(Random.Range(4, 6), Random.Range(-5, -3)), Quaternion.identity);
                        ObjectPool.Instantiate("RIGHTDOWN_Enemy", new Vector2(Random.Range(4, 6), Random.Range(-5, -3)), Quaternion.identity);
                        break;
                }
                break;
        }
        StartCoroutine(blackSpawn());
    }
}
