using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings
{
    public string language;
    public string playButton;
    public string velocityUM;
    public string velocityDOIS;
    public string waitForSecondsUM;
    public string waitForSecondsDOIS;
    public string tempo;
    
    private string path = "Assets/LanguageSettings.json";

    public void SaveLanguage()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path, content);
    }
    public void LoadLanguage()
    {
        var content = File.ReadAllText(path);
        var c = JsonUtility.FromJson<LanguageSettings>(content);

        language = c.language;
        playButton = c.playButton;
        velocityUM = c.velocityDOIS;
        waitForSecondsUM = c.waitForSecondsUM;
        waitForSecondsDOIS = c.waitForSecondsDOIS;
        tempo = c.tempo;
    }
}
