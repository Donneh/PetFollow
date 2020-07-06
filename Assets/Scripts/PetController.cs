using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public GameObject player;
    public int followDistance;
    private List<Vector3> storedPositions;
    public Animator anim;

    private void Awake()
    {
        anim.Play("anim_Idle_loop_5");
        storedPositions = new List<Vector3>();
    }
    
    void Update()
    {
        if(storedPositions.Count == 0)
        {
            storedPositions.Add(player.transform.position); //store the players currect position
            return;
        }else if (storedPositions[storedPositions.Count -1] != player.transform.position)
        {
            storedPositions.Add(player.transform.position); //store the position every frame
        }
 
        if (storedPositions.Count > followDistance)
        {
            anim.Play("closed_Roll_Loop");
            transform.position = storedPositions[0]; //move
            storedPositions.RemoveAt(0); //delete the position that player just move to
        }
    }
}
