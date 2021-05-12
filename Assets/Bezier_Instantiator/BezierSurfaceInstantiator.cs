using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSurfaceInstantiator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Parent;
    public float N;
    public float M;
    
    [Serializable]
    public class Column
    {
        public Transform[] CP;
    }
    public Column[] ControlPoints;

    private float currentU;
    private float currentV;

    // Start is called before the first frame update
    void Start()
    {
        currentU = 0;
        float incrementU = 1f/N;
        float incrementV = 1f/M;
        GameObject go;

        for(int i = 0;i<=N;i++){
            currentV = 0;
            for(int j=0;j<=M;j++){
                go = Instantiate(Prefab,Parent);
                BezierSurfaceFollower bzSF = go.GetComponent<BezierSurfaceFollower>();
                bzSF.script = this;
                bzSF.MyU = currentU;
                bzSF.MyV = currentV;
                currentV +=incrementV;
            }
            currentU += incrementU;
        }
    }
    float Binomial(int n, int k){
        return Factorial(n)/(Factorial(k)*Factorial(n-k));
    }
    float Factorial(int n){
        int nFact = 1;
        for(int i =0;i<n;i++){
            nFact = nFact * (n-i);
        }
        return nFact;
    }
    float Bni(int n, int i, float u){
        return Binomial(n,i)*Mathf.Pow(u,i)*Mathf.Pow(1-u,n-i);
    }
    public Vector3 BezierSurface(float u,float v){
        Vector3 BGivenT =Vector3.zero;
        int n =ControlPoints.Length;
        
        for(int i=0;i<n;i++){
            int m = ControlPoints[i].CP.Length;
            for(int j=0;j<m;j++){
                BGivenT += Bni(n-1,i,u)*Bni(m-1,j,v)*ControlPoints[i].CP[j].position;
            }
        }
        return BGivenT;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
