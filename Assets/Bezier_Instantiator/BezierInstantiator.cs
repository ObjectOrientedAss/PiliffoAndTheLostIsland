using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class BezierInstantiator : MonoBehaviour
{
    public List<Transform> BezierPoints;
    public List<GameObject> PrefabList;
    public Transform Parent;
    public int N;
    private float currentT;

    [Space]
    [Header("Random Rotation")]
    [Range(0, 360)] public float X_rot;
    [Range(0, 360)] public float Y_rot;
    [Range(0, 360)] public float Z_rot;
    public Vector3 Starting_rot;
    [Space]
    [Header("Random Rotation")]
    [Range(0, 10)] public float X_scale;
    [Range(0, 10)] public float Y_scale;
    [Range(0, 10)] public float Z_scale;
    public Vector3 Starting_scale;
    [Space]
    [Header("Instantiate!")]
    public bool Instantiate_objs;
    public bool Destroy_objs;
    // Start is called before the first frame update

    void Start()
    {
        //currentT = 0;
        //float increment = 1f/N;
        //GameObject go;
        //for(int i =0; i<=N;i++)
        //{
        //    //Debug.Log(currentT);
        //    go = Instantiate(Prefab,Parent);
        //    //go.transform.position = BezierCurve(currentT);
        //    BezierFollower bzf= go.GetComponent<BezierFollower>();

        //    bzf.script = this;
        //    bzf.MyT = currentT;
        //    currentT += increment;
        //}
    }
    void InstantiatePointsFixed()
    {
        currentT = 0;
        float increment = 1f / N;
        GameObject go;
        for (int i = 0; i <= N; i++)
        {
            //Debug.Log(currentT);
            go = Instantiate(PrefabList[Random.Range(0, PrefabList.Count)], Parent);
            //go.transform.position = BezierCurve(currentT);
            go.transform.rotation = Quaternion.Euler(GetRot());
            go.transform.localScale = GetScale();
            go.transform.position = BezierCurve(currentT);
            go.isStatic = true;
            currentT += increment;
        }
    }
    Vector3 GetScale()
    {
        Vector3 newScale = new Vector3(0, 0, 0);
        newScale.x = Random.Range(0, X_scale) + Starting_scale.x;
        newScale.y = Random.Range(0, Y_scale) + Starting_scale.y;
        newScale.z = Random.Range(0, Z_scale) + Starting_scale.z;
        return newScale;
    }
    Vector3 GetRot()
    {
        Vector3 newRot = new Vector3(0, 0, 0);

        newRot.x = Random.Range(0, X_rot)+Starting_rot.x;
        newRot.y = Random.Range(0, Y_rot)+Starting_rot.y;
        newRot.z = Random.Range(0, Z_rot)+Starting_rot.z;

        return newRot;
    }
    void Clear()
    {
        for (int i = Parent.childCount; i > 0; --i)
            DestroyImmediate(Parent.GetChild(0).gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Instantiate_objs)
        {
            Instantiate_objs = false;
            InstantiatePointsFixed();
        }
        if (Destroy_objs)
        {
            Destroy_objs = false;
            Clear();
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
}
