using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ScatterInstantiator : MonoBehaviour
{
    public GameObject O;
    public GameObject B;
    public bool Paint;
    public bool Undo;
    public int N_to_Place;
    public List<GameObject> Props_to_place;
    [Space]
    [Header("Random Rotation")]
    [Range(0, 360)] public float X_rot;
    [Range(0, 360)] public float Y_rot;
    [Range(0, 360)] public float Z_rot;
    public Vector3 Starting_rot;
    [Space]
    [Header("Random Scale")]
    [Range(0, 10)] public float X_scale;
    [Range(0, 10)] public float Y_scale;
    [Range(0, 10)] public float Z_scale;
    public Vector3 Starting_scale;
    public float Y_Offset;


    Stack<GameObject> StrokeHistory;
    void BrushStroke()
    {
        GameObject Parent = new GameObject();
        if(StrokeHistory == null)
        {
            StrokeHistory = new Stack<GameObject>();
        }
        Parent.name = "stroke_" + StrokeHistory.Count;

        for (int i = 0; i < N_to_Place; i++)
        {
            float ray_x = Random.Range(O.transform.position.x, B.transform.position.x);
            float ray_z = Random.Range(O.transform.position.z, B.transform.position.z);
            Ray ray = new Ray(new Vector3(ray_x, O.transform.position.y, ray_z), Vector3.down);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("TerrainLayer")))
            {
                GameObject go = Instantiate(Props_to_place[Random.Range(0, Props_to_place.Count)], Parent.transform);
                go.transform.position = hit.point + new Vector3(0,Y_Offset,0);
                go.transform.rotation = Quaternion.Euler(GetRot());
                go.transform.localScale = GetScale();
                go.isStatic = true;
            }
            
        }
        StrokeHistory.Push(Parent);
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

        newRot.x = Random.Range(0, X_rot) + Starting_rot.x;
        newRot.y = Random.Range(0, Y_rot) + Starting_rot.y;
        newRot.z = Random.Range(0, Z_rot) + Starting_rot.z;

        return newRot;
    }
    void UndoStroke()
    {
        GameObject go = StrokeHistory.Pop();
        for (int i = go.transform.childCount; i > 0; --i)
            DestroyImmediate(go.transform.GetChild(0).gameObject);
        DestroyImmediate(go);
    }
    // Update is called once per frame
    void Update()
    {
        if (Paint)
        {
            Paint = false;
            BrushStroke();
        }
        if (Undo)
        {
            Undo = false;
            UndoStroke();
        }
    }
}
