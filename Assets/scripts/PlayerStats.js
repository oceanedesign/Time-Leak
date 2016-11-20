#pragma strict

static var vie : float = 100.0;
var maxVie : float = 100.0;
var barTextureVieFond : Texture2D;
var barTextureVie : Texture2D;
var barTextureVieFinGame : Texture2D;
var barLargeurVie : float;
var pourcentageVie : float;

function OnGUI()
{
	if(vie >0)
	{
		//GUI.Box(Rect(10, 14, 40, 20), "Vie");
		GUI.DrawTexture(Rect(58,18,104, 14), barTextureVieFond);
		GUI.DrawTexture(Rect(60,20,barLargeurVie, 10), barTextureVie);
	}
		if(GameMaster.score == 5)
	{
		GUI.DrawTexture(Rect(60,20,barLargeurVie, 10), barTextureVieFinGame);
	}
}

function Update()
{
	pourcentageVie=vie/maxVie;
	barLargeurVie = pourcentageVie*100;

	vie -= Time.deltaTime*0.5; //enlève 0.5points de vie par seconde
	if(vie>maxVie){
	vie=maxVie;
	}

	if(GameMaster.score == 5)
	{
		vie=maxVie;
	}
}
