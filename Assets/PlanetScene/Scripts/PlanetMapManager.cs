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
	public Button currentProduction;
	public Text currentProductionProgress;
	public Text currentSelectedTile;
	public GameObject buildMenu;
	
	//
	private PlanetBoardGenerator boardGenerator;
	private Planet currPlanet;
	private int selectedTile;

	public PlanetMapManager()
	{
		selectedTile = -1;
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
		BuildingTypes.control.init();

		//make some planets as if it were a new game
		Planet testPlanet = new Planet();
		testPlanet.randomizePlanet(5, 5);
		testPlanet.playerId = 0;
		testPlanet.population = 10;
		testPlanet.labourAssignment[0] = 1;
		testPlanet.name = "Uldrakh";
		testPlanet.buildings[5] = 0;
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
		currPlanet = PlanetDataStore.control.getPlanet(planetId);
		planetName.text = currPlanet.name;

		refreshFreeLabour(calculateFreeLabour());		
		numWheatLabourers.text = currPlanet.labourAssignment[0].ToString();
				
		if (currPlanet.currProduction.goodId >= 0)
		{			
			currentProductionProgress.text = currPlanet.currProduction.progress + " / 100";
		}
		else
		{
			currentProductionProgress.text = "No current production";
		}
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

	public void planetTileSelect_onClick(int tileId)
	{
		selectedTile = tileId;

		//see if anything is being built here already
		if (currPlanet.buildings.ContainsKey(selectedTile))
		{
			int buildingTypeId = (int)currPlanet.buildings[selectedTile];
			Building selectedBuildingOnTile = (Building)BuildingTypes.control.buildingTypes[buildingTypeId];
			currentSelectedTile.text = selectedBuildingOnTile.name;
		}
		else
		{
			currentSelectedTile.text = "Nothing here";
		}
		
		buildMenu.SetActive(false);
	}

	public void selectConstruction_onClick()
	{
		if (-1 == selectedTile)
		{
			//we've no tile selected
			return;
		}
		else if (currPlanet.buildings.ContainsKey(selectedTile))
		{
			//something is already built here
			//todo: deconstruction?
			return;
		}

		buildMenu.SetActive(true);
	}

	public void buildingToConstruct_onClick(int goodId)
	{
		//todo: display a warning if replacing current production		
		//enqueue any current production
		currPlanet.productionProgress[currPlanet.currProduction.goodId] = currPlanet.currProduction;

		//find if we already have some progress on the choice and pull it out of the queue
		if (currPlanet.productionProgress.ContainsKey(goodId))
		{
			ConstructionQueueItem previousQueueItem = (ConstructionQueueItem)currPlanet.productionProgress[goodId];
			int progress = previousQueueItem.progress;
			currPlanet.currProduction = new ConstructionQueueItem(goodId, progress);

			currPlanet.productionProgress.Remove(goodId);
		}
		
		//set the location of the current production
		//todo: starships have selectedTile of -1
		currPlanet.currProductionTileId = selectedTile;
				
		//display the progress		
		currentProductionProgress.text = currPlanet.currProduction.progress.ToString() + " / 100";

		//hide the build menu after making a choice
		buildMenu.SetActive(false);
	}
}
