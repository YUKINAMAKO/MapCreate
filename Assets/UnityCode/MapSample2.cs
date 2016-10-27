using UnityEngine;
using System.Collections;

public class MapSample2 : MonoBehaviour
{
    public TextAsset _layout;
    public GameObject[] _objs;

    // Use this for initialization
    void Start()
    {
        this.readMap();
    }

    void readMap()
    {
        string[] layoutInfo = _layout.text.Split('\n');

        string[] eachInfo;
        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);

            GameObject obj = _objs[0];
            Vector2 pos = new Vector2(int.Parse(eachInfo[0]),
                                      int.Parse(eachInfo[1]));
            this.createObj(obj, pos);
        }
    }



    void createObj(GameObject obj, Vector2 pos)
    {
        GameObject go = Instantiate(obj, new Vector3(pos.x, 0, pos.y), obj.transform.rotation) as GameObject;
    }
}