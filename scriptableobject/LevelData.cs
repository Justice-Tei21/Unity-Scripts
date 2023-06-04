using Cinemachine;
using UnityEngine;

//should start using this so that i won't have to worry about
//which things have been configured in a cerain scene
class LevelData: ScriptableObject
{
    public GameObject player;

    public EventMaker Eventus;

    public GameObject cameracontroller;

    public CinemachineBlendListCamera CinemachineBlendListCamera;

    public LayerMask environmentlayer;
}

