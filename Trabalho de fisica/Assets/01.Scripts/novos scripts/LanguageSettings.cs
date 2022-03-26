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
    
    private string pathPT = "Assets/LanguageSettingsPT.json";
    private string pathEUA = "Assets/LanguageSettingsEUA.json";

    public void LoadLanguagePT()
    {
        var content = File.ReadAllText(pathPT);
        var ptbr = JsonUtility.FromJson<LanguageSettings>(content);

        language = ptbr.language;
        playButton = ptbr.playButton;
        velocityUM = ptbr.velocityDOIS;
        waitForSecondsUM = ptbr.waitForSecondsUM;
        waitForSecondsDOIS = ptbr.waitForSecondsDOIS;
        tempo = ptbr.tempo;
    }
    public void LoadLanguageEUA()
    {
        var content = File.ReadAllText(pathEUA);
        var eua = JsonUtility.FromJson<LanguageSettings>(content);

        language = eua.language;
        playButton = eua.playButton;
        velocityUM = eua.velocityDOIS;
        waitForSecondsUM = eua.waitForSecondsUM;
        waitForSecondsDOIS = eua.waitForSecondsDOIS;
        tempo = eua.tempo;
    }
}
