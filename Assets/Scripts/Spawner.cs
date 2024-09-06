using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnpos;
    // Start is called before the first frame update
    void Start()
    {
        int spawn = Random.Range(0,spawnpos.Length);
        PhotonNetwork.Instantiate("Player", spawnpos[spawn].position, Quaternion.identity);
    }
}
