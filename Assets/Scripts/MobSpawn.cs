using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private float[] spawnPercentages;
    [SerializeField] private GameObject[] enemiesToSpawn;
    [SerializeField] private GameObject bodyToSpawn;
    [SerializeField] private float spawningRate;
    private float timerForSpawn = 0f;
    private void FixedUpdate()
    {
        timerForSpawn -= Time.fixedDeltaTime;
        if(timerForSpawn <= 0f)
        {
            Instantiate(enemiesToSpawn[indexForSpawn()], spawnPositions[indexForTransform()]);
            timerForSpawn = spawningRate;
        }
    }
    private int indexForSpawn()
    {
        float rand = Random.Range(0f, 1f);
        float numberToAdd = 0f;
        float totalWeight = 0f;
        for (int i = 0; i < spawnPercentages.Length; i++)
        {
            totalWeight += spawnPercentages[i];
        }

        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            if (spawnPercentages[i] / totalWeight + numberToAdd >= rand)
            {
                return i;
            }
            else
            {
                numberToAdd += spawnPercentages[i] / totalWeight;
            }
        }
        return 0;
    }
    private int indexForTransform() // TODO: Спавнитись моби мають не блище певної відтані до ГГ
    {
        int random = Random.Range(0, spawnPositions.Length);
        return random;
    }

}
