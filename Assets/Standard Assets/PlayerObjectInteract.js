 //Has to go at the top of your file
 #pragma strict
 import System.Collections.Generic;
 
 //The list of colliders currently inside the trigger
 public static var TriggerList : List.<Collider> = new List.<Collider>();
 
 //called when something enters the trigger
 function OnTriggerEnter(other : Collider)
 {
     //if the object is not already in the list
     if(!TriggerList.Contains(other))
     {
         //add the object to the list
         TriggerList.Add(other);
     }
 }
 
 //called when something exits the trigger
 function OnTriggerExit(other : Collider)
 {
     //if the object is in the list
     if(TriggerList.Contains(other))
     {
         //remove it from the list
         TriggerList.Remove(other);
     }
 }

 public static function isObjectInPlayerInteractiveZone( other: Collider){
 	var result : boolean = false;

 	if(TriggerList.Contains(other))
 		result = true;
 	
 	return result;
 }