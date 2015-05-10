﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamingGUI : MonoBehaviour {

	// Use this for initialization
	public Text ScoreText;
	public Text TimeText;
	public Text GoldText;
	public Text ClipText;
	public Text CurrentHPText;
	public Image CurrentHPImage;
	private GameAttribute gameAttribute;
	void Start () {
		gameAttribute = GameAttribute.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameAttribute == null){
			gameAttribute = GameAttribute.instance;
		}
		ScoreText.text = gameAttribute.Score.ToString();
		setTimeText ();
		GoldText.text = gameAttribute.Gold.ToString ();
		setClipText ();
		setCurrentHPText ();
	}

	private void setTimeText(){
		string minute = gameAttribute.Minute.ToString();
		string second = "";
		if (gameAttribute.Second < 10) {
			second = "0"+gameAttribute.Second.ToString();
		}else{
			second = gameAttribute.Second.ToString();
		}
		TimeText.text = minute + ":" + second;
	}

	private void setClipText(){
		string clip = gameAttribute.Clip.ToString ();
		string leftClip = gameAttribute.LeftClip.ToString ();
		ClipText.text = clip + "/" + leftClip;
	}

	private void setCurrentHPText(){
		float result = gameAttribute.playerCurrentHealth / gameAttribute.playerMaxHealth;
		CurrentHPText.text = (result * 100).ToString() + "%";
		setCurrentImageText (result);
	}

	private void setCurrentImageText(float percent){
		CurrentHPImage.fillAmount = percent;
	}
}
