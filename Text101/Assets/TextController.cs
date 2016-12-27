using UnityEngine;
using UnityEngine.UI; //to use Text UI
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States{
		cell, mirror, sheets_0, lock_0, sheets_1, lock_1, cell_mirror, 
		corridor_0, corridor_1, corridor_2, corridor_3, stairs_0, stairs_1, stairs_2,
		floor, closet_door, in_closet, courtyard
	};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if(myState == States.cell)				{cell();} 
		else if(myState == States.sheets_0)		{sheets_0();} 
		else if(myState == States.lock_0)		{lock_0();} 
		else if(myState == States.mirror)		{mirror();} 
		else if(myState == States.cell_mirror)	{cell_mirror();} 
		else if(myState == States.sheets_1)		{sheets_1();} 
		else if(myState == States.lock_1)		{lock_1();} 
		else if(myState == States.corridor_0)	{corridor_0();}
		else if(myState == States.corridor_1)	{corridor_1();}
		else if(myState == States.corridor_2)	{corridor_2();}
		else if(myState == States.corridor_3)	{corridor_3();}
		else if(myState == States.stairs_0)		{stairs_0();}
		else if(myState == States.stairs_1)		{stairs_1();}
		else if(myState == States.stairs_2)		{stairs_2();}
		else if(myState == States.floor)		{floor();}
		else if(myState == States.closet_door)	{closet_door();}
		else if(myState == States.in_closet)	{in_closet();}
		else if(myState == States.courtyard)	{courtyard();} 
	}
	
	#region State handler methods
	void cell(){
		text.text = "You are in a prison cell, and you want to escape. There are " + 
					"some dirty sheets on the bed, a mirror on the wall, and the door " + 
					"is locked from the outside.\n\n" + 
					"Press S to view sheets, M to view mirror, or L to view lock.";
	
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		} else if(Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		} else if(Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		}
	}
	
	void cell_mirror(){
		text.text = "You are in a prison cell, and you want to escape. " + 
					"You now have the mirror you just picked up.\n\n" + 
					"Press S to view sheets, L to view lock.";
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_1;
		} else if(Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1;
		}
	}
	
	void sheets_0(){
		text.text = "You can't believe you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life. I guess!\n\n" + 
					"Press R to Return to roaming your cell.";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	void sheets_1(){
		text.text = "You look at the sheets once again in disbelief. " + 
					"It makes your skin crawl that someone would sleep on those sheets.\n\n" + 
					"Press R to Return to roaming your cell.";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		}
	}
	
	void lock_0(){
		text.text = "This is one of those button locks. You have no idea what the combination is.\n\n" + 
					"Press R to Return to roaming your cell";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	void lock_1(){
		text.text = "You push the mirror through the gap inbetween the door frame and the door the lock is on. " + 
					"You see the fingerprints on the buttons and deduce correctly what the password is." +
					"The lock clicks and the door opens.\n\n" + 
					"Press L to leave your cell.";
		
		if(Input.GetKeyDown(KeyCode.L)){
			myState = States.corridor_0;
		}
	}

	void mirror(){
		text.text = "You notice the mirror's detachable from the wall.\n\n" + 
					"Press T to take the mirror, or R to return to roaming you cell";
		
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.cell_mirror;
		} else if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	void corridor_0(){
		text.text =	"You are now in an open corridor at the prison.\n\n" + 
					"Press S to go up stairs, F to look at the floor, or C to look at the closet";
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_0;
		} else if(Input.GetKeyDown(KeyCode.F)){
			myState = States.floor;
		} else if(Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_door;
		}
	}
	
	void corridor_1(){
		text.text =	"You went back to the corridor. You now have the hairclip you picked up with you.\n\n" + 
					"Press S to go up stairs, or P to pick the locked closet doors";
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_1;
		} else if(Input.GetKeyDown(KeyCode.P)){
			myState = States.in_closet;
		}
	}
	
	void corridor_2(){
		text.text =	"You went back to the corridor. The closet door is now open.\n\n" + 
					"Press S to go up stairs, or C to look at the contents of the closet";
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_2;
		} else if(Input.GetKeyDown(KeyCode.C)){
			myState = States.in_closet;
		}
	}
	
	void corridor_3(){
		text.text =	"You go back out the corridors dressed as a custodian. Looking at yourself with the mirror" +
					" you picked up earler, you couldn't even tell that the person looking back at your reflection was you.\n\n" + 
					"Press S to go up stairs, or U to undress and put the clothes back in the closet";
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.courtyard;
		} else if(Input.GetKeyDown(KeyCode.U)){
			myState = States.in_closet;
		}
	}
	
	void stairs_0(){
		text.text = "You walk up the stairs that lead to the courtyard. You see a guard patrolling the area and run back to the corridor.\n\n" + 
					"Press R to return to roaming the corridor";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}
	
	void stairs_1(){
		text.text = "You walk up the stairs that lead to the courtyard again. The guard is still patrolling the area." +
					"It would be unwise to make a break for it now.\n\n" + 
					"Press R to return to roaming the corridor";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_1;
		}
	}
	
	void stairs_2(){
		text.text = "You walk up the stairs that lead to the courtyard again. The guard is still patrolling the area." +
					"If only there was a way to walk past the guard without them noticing...\n\n" + 
					"Press R to return to roaming the corridor";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_2;
		}
	}
	
	void floor(){
		text.text = "You look down at the floor and you noticed a hairclip. It might come in handy later...\n\n" + 
					"Press H to pick up the hairclip, or R to return to roaming the corridor";
		
		if(Input.GetKeyDown(KeyCode.H)){
			myState = States.corridor_1;
		} else if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}
	
	void closet_door(){
		text.text = "You look at the closet that was near the cell exit. The closet doors are closed shut.\n\n" + 
					"Press R to return to roaming the corridor";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}
	
	void in_closet(){
		text.text = "You picked the closet doors open and inside it, you see a custodian's uniform. Huh.\n\n" + 
					"Press R to return to roaming the corridor, or D to dress up in the custodian uniform";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_1;
		} else if(Input.GetKeyDown(KeyCode.D)){
			myState = States.corridor_3;
		}
	}
	
	void courtyard(){
		text.text = "You go up the stairs and the police sees you. They give you a friendly greeting." +
					" They didn't suspect anything has gone awry. As soon as you leave the courtyard's perimeter, you make a run for it." +
					"\n\nYou are free. Congratulations!\n" + 
					"Press P to play again";
		
		if(Input.GetKeyDown(KeyCode.P)){
			myState = States.cell;
		}
	}
	#endregion
}
