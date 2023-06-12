using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public List<ParticleSystem> stepTakeParticles=new List<ParticleSystem>();

    private int index;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPlayerTakeStep,OnPlayerTakeStep);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPlayerTakeStep,OnPlayerTakeStep);
    }

    private void OnPlayerTakeStep()
    {
        MakeRandom();
        stepTakeParticles[index].Play();
    }

    private int MakeRandom()
    {
        index=Random.Range(0,stepTakeParticles.Count);
        return index;
    }
}
