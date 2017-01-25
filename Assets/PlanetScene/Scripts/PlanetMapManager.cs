using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 
 * This class is for handling the scene creation and changes
 * 
 */
public class PlanetMapManager : MonoBehaviour
{
	public static PlanetMapManager control;

	//UI Elements
	public Text planetName;
	public Text freeLabourText;
	public Text numWheatLabourers;

	private PlanetBoardGenerator boardGenerator;
	private Planet currPlanet;

	public PlanetMapManager()
	{		
	}

	// Use this for initialization
	void Awake()
	{
		if (null == control)
		{
			DontDestroyOnLoad(gameObject);
			control = this;

			boardGenerator = GetComponent<PlanetBoardGenerator>();
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}
	}

	// todo: remove test function
	private void Start()
	{
		//init game as if this were the game state manager
		ResourceTypes.control.init();

		//make some planets as if it were a new game
		Planet testPlanet = new Planet();
		testPlanet.randomizePlanet(5, 5);
		testPlanet.playerId = 0;
		testPlanet.population = 10;
		testPlanet.labourAssignment[0] = 1;
		testPlanet.name = "Uldrakh";
		PlanetDataStore.control.AddPlanet(1, testPlanet);

		//draw the scene as if the player clicked into planet with id 1
		PlanetMapStateTransition.control.planetId = 1;
		PlanetMapStateTransition.control.playerId = 0;
		InitPlanetMap();
	}

	public void InitPlanetMap()
	{
		int planetId = PlanetMapStateTransition.control.planetId;
		boardGenerator.setupScene(planetId);

		//fill out dynamic information like planet name
		currPlanet = PlanetDataStore.control.GetPlanet(planetId);
		planetName.text = currPlanet.name;

		refreshFreeLabour(calculateFreeLabour());		
		numWheatLabourers.text = currPlanet.labourAssignment[0].ToString();
	}

	private int calculateFreeLabour()
	{
		int freeLabourers = currPlanet.population;

		IDictionaryEnumerator labourAssignmentEnumerator = currPlanet.labourAssignment.GetEnumerator();
		DictionaryEntry labourAssignmentEntry;

		while (labourAssignmentEnumerator.MoveNext())
		{
			labourAssignmentEntry = (DictionaryEntry)labourAssignmentEnumerator.Current;
			freeLabourers = freeLabourers - (int)labourAssignmentEntry.Value;
		}

		return freeLabourers;
	}

	private void refreshFreeLabour(int numFreeLabour)
	{
		freeLabourText.text = "Free Labourers: " + numFreeLabour.ToString();
	}

	//UI functionality
	public void wheatAddLabour_onClick()
	{
		//check if there is sufficient free labour
		int freeLabour = calculateFreeLabour();
		if (freeLabour <= 0)
		{
			return;
		}

		//assign the labour
		currPlanet.labourAssignment[0] = (int)currPlanet.labourAssignment[0] + 1;
		refreshFreeLabour(freeLabour - 1);
		numWheatLabourers.text = currPlanet.labourAssignment[0].ToString();
	}

	public void wheatSubtractLabour_onClick()
	{
		//check if there is any labour assigned
		if ((int)currPlanet.labourAssignment[0] <= 0)
		{
			return;
		}

		//assign the labour
		currPlanet.labourAssignment[0] = (int)currPlanet.labourAssignment[0] - 1;
		refreshFreeLabour(calculateFreeLabour());
		numWheatLabourers.text = currPlanet.labourAssignment[0].ToString();
	}
}
