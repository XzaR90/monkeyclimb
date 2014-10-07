using UnityEngine;
using System.Collections;

namespace MenuControllers
{
	public class StartMenuController : MonoBehaviour {


		void Start () {
		
		}
		

		void Update () {

			bool continueButton = false;

			continueButton |= Input.GetButtonDown("Fire1");
			continueButton |= Input.GetButtonDown("Fire2");
			continueButton |= Input.GetButtonDown("Exit");

			if(continueButton)
			{
				Application.LoadLevel("MainMenu");
			}
		
		}
	}
}