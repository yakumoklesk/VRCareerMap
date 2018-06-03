using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartJustHiredJunior();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void StartJustHiredJunior()
    {
        var justHiredJuniorPath = iTweenPath.GetPath("JustHiredJuniorPath");
        iTween.MoveTo(gameObject, iTween.Hash("path", justHiredJuniorPath, "id", "JustHiredJuniorPath", "time", 60, "orienttopath", true, "looptype", iTween.LoopType.none, "lookahead", 0.001f, "looktime", 0.001f, "easetype", iTween.EaseType.linear, "movetopath", false, "oncomplete", "StartJuniorToProfessional")); 
        //lookahead and looktime help correct orientation. they seem to indicate the location of the next point used to calculate the lookahead target and how often the calculation is performed
    }

    private void StartJuniorToProfessional()
    {
        var path = iTweenPath.GetPath("JuniorToProfessionalPath");
        iTween.MoveTo(gameObject, iTween.Hash("path", path, "id", "JuniorToProfessionalPath", "time", 60, "orienttopath", true, "looptype", iTween.LoopType.none, "lookahead", 0.001f, "looktime", 0.001f, "easetype", iTween.EaseType.linear, "movetopath", false, "delay", 5)); 
    }

    private void StartProfessionalToSenior()
    {
        var path= iTweenPath.GetPath("ProfessionalToSeniorPath");
        iTween.MoveTo(gameObject, iTween.Hash("path", path, "id", "ProfessionalToSeniorPath", "time", 60, "orienttopath", true, "looptype", iTween.LoopType.none, "lookahead", 0.001f, "looktime", 0.001f, "easetype", iTween.EaseType.linear, "movetopath", false, "delay", 5));
    }
}
