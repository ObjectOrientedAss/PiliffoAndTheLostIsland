using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutInstantiator : MonoBehaviour
{
    public GameObject CoconutPrefab;
    public int MaxCoconuts;
    public float Radius;
    public float RandomNoise;
    // Start is called before the first frame update
    void Start()
    {
        int coconutNum =Random.Range(0, MaxCoconuts + 1);
        if(coconutNum == 0)
        {
            return;
        }
        float angleDelta = 360 / coconutNum;
        float currAngle = 0;
        for (int i = 0; i < coconutNum; i++)
        {
            GameObject go = Instantiate(CoconutPrefab, transform);
            float noiseX = Random.Range(-RandomNoise, RandomNoise);
            float noiseY = Random.Range(-RandomNoise, RandomNoise);
            go.transform.localPosition = new Vector3(Mathf.Cos(currAngle*Mathf.Deg2Rad + noiseX), 0, Mathf.Sin(currAngle* Mathf.Deg2Rad+noiseY)) * Radius;
            currAngle += angleDelta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
