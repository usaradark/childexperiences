using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABHandler : MonoBehaviour
{
    public bool coinFlipHeads;
    public float charaSpeed;
    public GameObject eventHandler;
    public GameObject statManager;
    public GameObject panel;

    private CharacterController myController;
    private EventFunctions functions;

    private StatsManagerController smc;
    private string currentTrigger;

    public bool canControl;

    public string currentTag;

    bool leftChoice = true;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        functions = eventHandler.GetComponent<EventFunctions>();
        smc = statManager.GetComponent<StatsManagerController>();
        currentTrigger = "";
        canControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (canControl)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);
            myController.SimpleMove(playerMove * charaSpeed);
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && canControl)
        {
            Debug.Log("E pressed in Stay");
            if(Random.Range(0, 2) == 1)
            {
                coinFlipHeads = true;
            }
            else
            {
                coinFlipHeads = false;
            }
            canControl = false;
            panel.gameObject.SetActive(true);
            currentTag = collider.gameObject.tag;
            switch (currentTag)
            {
                //ADD CHECKS TO INV BEFORE FINAL TEST
                case "Stove":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Make Food?";
                    break;
                case "Hole":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Use wood to repair hole?";
                    break;
                case "Med Cabinet":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Use medicine?";
                    break;
                case "Fire":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Use wood to make Fire?";
                    break;
                case "Door":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Leave house?";
                    break;


                //outdoor
//Hardware
                case "Hardware":
                    if (coinFlipHeads)
                    {
                        currentTag = "HardwareA";
                        panel.transform.GetChild(0).GetComponent<Text>().text = "You arrive at the hardware store, remembering how happy your father was every time he came to this once bustling place. You feel extra lonely seeing the store abandoned and empty.";
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Scavenge for wood";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Search for tools";
                    }
                    else
                    {
                        currentTag = "HardwareB";
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Your hear the sounds of construction ringing out from the back lot. You peek around the corner of the building and see a burly man sawing huge chunks of plywood into more manageable sections. He stops and stares at you for a while and continues to cut wood.";
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Cautiously approach";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Back away cautiously and look elsewhere";
                    }
                    break;
//Forest
                case "Forest":
                    if (coinFlipHeads)
                    {
                        currentTag = "ForestA";
                        panel.transform.GetChild(0).GetComponent<Text>().text = "As you venture deeper into the forest, the trees begin to block out most of the sunlight. Through the scattered light you spy a small doe drinking from a muddy pond.";
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Hunt the deer with your makeshift bow";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Leave the animal in peace and try to snap some of the larger branches off to bring home.";
                    }
                    else
                    {
                        currentTag = "ForestB";
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Most of the once lush trees are dead and brittle, but you do find a few berry bushes and mushrooms under some of the in what is left of the undergrowth.";
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Harvest the berries and mushrooms ";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Try to find usable wood";
                    }
                    break;
//Grocery
                case "Grocery":
                    if(coinFlipHeads)
                    {
                        currentTag = "GroceryA";
                        panel.transform.GetChild(0).GetComponent<Text>().text = "The shelves of your local grocery store are mostly picked clean, but you manage to find several fallen over shelves amongst the empty aisles.";
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Search for food";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Dismantle the shelf for wood";
                    }
                    else
                    {
                        currentTag = "GroceryB";
                        panel.transform.GetChild(0).GetComponent<Text>().text = "A makeshift swap meet has formed outside the store. Individuals are selling their minor possessions or garden grown vegetables. You find a wheelchair-bound women offering surprisingly healthy produce.";
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Trade medicine for food";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Trade Wood for food";
                    }
                    break;
   

            }
        }
    }

    public void OperateOnTag(string tag)
    {
        switch (tag)
        {
            case "Stove":
                if (leftChoice)
                {
                    //Who to give food to?
                    currentTag = "Stove2";
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Feed Mom or Yourself?";
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "Stove2":
                if (leftChoice)
                {
                    //Give food to mom
                    functions.MomEatFood();
                }
                else
                {
                    //Give food to self
                    functions.SelfEatFood();
                }
                canControl = true;
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                break;

            case "Hole":
                if(leftChoice)
                {
                    //patch the hole
                    functions.HomeRepairRoof();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "Med Cabinet":
                if (leftChoice)
                {
                    //Who to give medicine to?
                    currentTag = "Med Cabinet 2";
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Heal Mom or Yourself?";
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "Med Cabinet 2":
                if (leftChoice)
                {
                    //Give medicine to mom
                    functions.MomTakeMedicine();
                }
                else
                {
                    //Give medicine to self
                    functions.SelfTakeMedicine();
                }
                canControl = true;
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                break;

            case "Fire":
                if (leftChoice)
                {
                    //make the fire
                    functions.CreateFire();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "Door":
                if (leftChoice)
                {
                    //Leave House
                    //function to leave house called here
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;
//hardware
            case "HardwareA":
                if (leftChoice)
                {
                    Debug.Log("In the lumber section you manage to find a few relatively undamaged boards of plywood. You awkwardly hoist them onto your back and begin the walk home.");
                    functions.HarborA1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("Hammers, screwdrivers, nails: it’s all still here. You grab a small bucket and patrol the aisles grabbing whatever you recognized from that DIY house projects show your dad used to watch.");
                    functions.HarborA2();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;
//Hardware
            case "HardwareB":
                if (leftChoice)
                {
                    Debug.Log("You see the man sanding down the damaged planks into finer lumber. He looks up again from his work and sees you carefully walking towards him. He pulls off his glasses and beckons you over. “Hey there, kid. Could you run over there and get me my tools? You do that and I’ll make sure you don’t walk home empty handed.” You quickly make it to his shed and grab his stuff. He thanks you and tells you to grab as much wood as you can.");
                    functions.HarborB1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("Who knows what that guy was up to, especially with all those sharp tools laying about, better to play it safe. You walk to the old employee’s lounge and find some canned goods. You take them hoping the man doesn’t mind.");
                    functions.HarborB2();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;
//forest
            case "ForestA":
                if (leftChoice)
                {
                    Debug.Log("The bow thrums and your arrow manages to hit the doe in the neck. The animal gurgles her yelps in pain and runs off a short distance before collapsing with you in tow. Under your breath you thank those archery lessons from summer camp. Finally the doe succumbs to its wound and you begin to slowly drag the carcass back home. “If you must hunt, make sure you waste none of the animal’s sacrifice” your mom used to say.");
                    functions.ForestA1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("“Enough things have died around this town, this poor fella probably lost his parents too” you say as you begin to tear at nearby branches. With a solid crack you dislodge a sizable branch from a dead tree, out of the corner of your eye you see the doe sprint off deeper into the forest.");
                    functions.ForestA2();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "ForestB":
                if (leftChoice)
                {
                    Debug.Log("You recognize the edible berries from back when your parents took you to the woods to go berry foraging. You pick the bushes and logs clean of their bounty. It’s not much, but it’s better than nothing.");
                    functions.ForestB1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("Most of these trees yield useless wood. You poke around the ground trying to find a few larger branches with some strength left in them. You finally find one, hoist half of it on your shoulder and begin dragging it home.");
                    functions.ForestB2();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

//grocery
            case "GroceryA":
                if (leftChoice)
                {
                    //Leave House
                    //function to leave house called here
                    Debug.Log("It pays to be small sometimes, you quip as you crawl under a few collapsed shelves. Jackpot -- you find several cans of soup that must have rolled under after the shelves collapsed.");
                    functions.GroceryA1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("No use crawling around on the floor for whatever the rats left behind. A few of the shelves still have some sturdy planks that you manage to pry free. Lifting one plank reveals medicine, which you take.");
                    functions.GroceryA2();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "GroceryB":
                if(leftChoice)
                {
                    Debug.Log("'Excuse me, Miss.' you say looking at the cornucopia on display on her cart. “How may I help you, child”. She replies sweetly. “How much for the pumpkin, I’ve only seen them in story books. I have medicine to trade” “Lord knows I could use a few planks to fix up my old ramp, I'll trade you the pumpkin for one of those planks,” You put wood alongside her stand and grab the pumpkin wondering what you can make at home with it.");
                    functions.GroceryB1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("'Excuse me, Miss.' you say looking at the cornucopia on display on her cart. “How may I help you, child”. She replies sweetly. “How much for the pumpkin, I’ve only seen them in story books. I have medicine to trade” “Lord knows I could use a few of those, toss me one and the pumpkin is all yours,” You hand over medicine and grab the pumpkin wondering what you can make at home with it.");
                    functions.GroceryB2();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;
        }
        functions.UpdateAll();
    }

    public void A()
    {
        leftChoice = true;
        OperateOnTag(currentTag);
    }

    public void B()
    {
        leftChoice = false;
        OperateOnTag(currentTag);
    }

}
