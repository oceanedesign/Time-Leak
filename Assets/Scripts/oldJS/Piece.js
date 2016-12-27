#pragma strict

var valeurPiece = 1;
var ajoutVie : float = 10.0;

function OnTriggerEnter(info:Collider) 
{
	if(info.tag=="Player")
	{
		GameMaster.score += valeurPiece;
		PlayerStats.vie += ajoutVie;
		Destroy(gameObject);
	}

}

