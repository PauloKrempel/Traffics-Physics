using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharacterCar
{
    public float speed01;
    public float speed02;
    public int waitSeconds01;
    public int waitSeconds02;
    public int secondsAssigned01;
    public int secondsAssigned02;
    public float encontroTime;

    private string path = @"Assets/CharacterCar.json";

    public void SaveCharacter()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path, content);
    }
    public void LoadCharacter()
    {
        var content = File.ReadAllText(path);
        var c = JsonUtility.FromJson<CharacterCar>(content);

        speed01 = c.speed01;
        speed02 = c.speed02;
        waitSeconds01 = c.waitSeconds01;
        waitSeconds02 = c.waitSeconds02;
        secondsAssigned01 = c.secondsAssigned01;
        secondsAssigned02 = c.secondsAssigned02;
        encontroTime = c.encontroTime;
    }
}
