#pragma strict

static var score : int = 0;


function OnGUI()
{
	GUI.Box(Rect(58,40,100, 20), "Score : "+score);

	if(score==5)
	{
		GUI.Box(Rect(200, 40, 100, 30), "Gagné !");
	}

}