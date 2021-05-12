using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierLineFollower : MonoBehaviour
{
    public List<Transform> BezierPoints;
    public float TimeToReachStart;
    public float TimeToReachEnd;
    public AnimationCurve TimeToReachCurve;
    public bool Follow;
    float currT;

    private void OnDestroy()
    {
        GameEventSystem.WinGameEvent -= WinGame;
    }

    private void Start()
    {
        currT = 0;
        GameEventSystem.WinGameEvent += WinGame;
    }

    void Update()
    {

        if (Follow)
        {
            float TimeToReach = Mathf.Lerp(TimeToReachStart, TimeToReachEnd, TimeToReachCurve.Evaluate(currT));
            currT += Time.deltaTime / TimeToReach;
            if (currT >= 1)
            {
                currT = 1;
                Follow = false;
            }
            transform.position = BezierCurve(currT);
        }
    }
    float Factorial(int n)
    {
        int nFact = 1;
        for (int i = 0; i < n; i++)
        {
            nFact = nFact * (n - i);
        }
        return nFact;
    }
    float Binomial(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    public Vector3 BezierCurve(float t)
    {
        Vector3 BGivenT = Vector3.zero;
        int n = BezierPoints.Count;
        for (int i = 0; i < n; i++)
        {
            BGivenT += Binomial(n - 1, i) * Mathf.Pow((1 - t), n - 1 - i) * Mathf.Pow(t, i) * BezierPoints[i].position;
        }
        return BGivenT;
    }

    void WinGame()
    {
        Follow = true;
    }
}
