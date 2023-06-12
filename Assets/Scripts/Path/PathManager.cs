using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<PathControl> paths=new List<PathControl>();

    public List<Vector3> positions=new List<Vector3>();

    [SerializeField] private bool canShuffle;

    private void OnEnable()
    {
        if(canShuffle)
            MakeRandomPos();
    }

  
    private void MakeRandomPos()
    {
        paths.Shuffle(paths.Count);
        for (int i = 0; i < paths.Count; i++)
        {
            paths[i].transform.localPosition=positions[i];
            //targets[i].localRotation=Quaternion.Euler(rotations[i]);
        }
    }

   


}
