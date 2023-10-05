using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    private List<GameObject> powerUpList;
    [SerializeField] private List<GameObject> powerUpTemplateList;

    public int spawnInterval;
    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            RemoveRandomPowerUp();      //cobak2
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if(powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }
        
        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }

    //switch unused power up with a new one

    public void RemoveRandomPowerUp()
    {
        if(powerUpList.Count >= maxPowerUpAmount)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
