﻿using GAMI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GAMI.AudioGameObject))]
[DisallowMultipleComponent()]
[AddComponentMenu("GAMI/MovingMultiPositionSound")]
public class MovingMultiPositionSound : MonoBehaviour
{
    public string soundEvent;
    public AkMultiPositionType positionType = AkMultiPositionType.MultiPositionType_MultiDirections;
    public List<Vector3> positionList = new List<Vector3>();
    private AkPositionArray positionArray;


    void Start()
    {
        positionArray = new AkPositionArray((uint)positionList.Count);
        AudioManager.Instance.PlaySound(soundEvent, gameObject);
    }


    void Update()
    {
        if (!HasMoved()) { return; }

        if (positionType != AkMultiPositionType.MultiPositionType_SingleSource)
        {
            BuildAkPositionArray();
            AkSoundEngine.SetMultiplePositions(gameObject, positionArray, (ushort)positionList.Count, positionType);
        }
    }

    private Vector3 last_Position;
    private int last_Index = 0;
    private bool HasMoved()
    {
        if (++last_Index <= 5) { return false; }
        
        last_Index = 0;

        if (!transform.position.Equals(last_Position))
        {
            last_Position = transform.position;
            return true;
        }
        return false;
    }



    /// <summary>
    /// 生成多点位置数据
    /// </summary>
    /// <returns></returns>
    private void BuildAkPositionArray()
    {
        positionArray.Reset();
        for (int i = 0; i < positionList.Count; ++i)
        {
            positionArray.Add(positionList[i] + transform.position, transform.forward, transform.up);
        }
    }
}