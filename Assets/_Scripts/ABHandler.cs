using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABHandler : MonoBehaviour
{
    public bool coinFlipHeads;
    public bool gameOver;
    public bool momDead;
    public bool gameWon;
    public GameObject eventHandler;
    public GameObject statManager;
    public GameObject panel;
    public GameObject okPanel;
    public GameObject sceneHandler;

    private Text panelMainText;
    private Text panelOkText;
    private Text buttonAText;
    private Text buttonBText;

    private EventFunctions functions;

    private StatsManagerController smc;
    private SceneInteract sceneManager;
    private bool hasBeenOutside;

    public bool canControl;

    public string currentTag;

    bool leftChoice = true;

    private bool EwasPressed;
    private float timeSinceLastEWasPressed;
    public float ETimeout;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastEWasPressed = 0;
        EwasPressed = false;
        functions = eventHandler.GetComponent<EventFunctions>();
        smc = statManager.GetComponent<StatsManagerController>();
        canControl = true;
        hasBeenOutside = false;
        sceneManager = sceneHandler.GetComponent<SceneInteract>();
        panelMainText = panel.transform.GetChild(0).GetComponent<Text>();
        buttonAText = panel.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        buttonBText = panel.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        panelOkText = okPanel.transform.GetChild(0).GetComponent<Text>();
        panelOkText.text = "";
        okPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canControl)
        {
            EwasPressed = true;
            timeSinceLastEWasPressed = 0;
        }
        timeSinceLastEWasPressed += Time.deltaTime;
        if(timeSinceLastEWasPressed > ETimeout)
        {
            EwasPressed = false;
            timeSinceLastEWasPressed = 0;
        }
        if (gameOver)
        {
            EndGame();
        }
        
        if (gameWon)
        {
            WinGame();
        }
    }

    public void ObjectInteracted(string tag)
    { 
        if (EwasPressed && canControl)
        {
            //Debug.Log("E pressed in Stay");
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
            currentTag = tag;
            string msg = "";
            switch (currentTag)
            {
                case "Bed":
                    panelMainText.text = "Sleep?";
                    break;
                case "Stove":
                    if (smc.myFood > 0)
                        panelMainText.text = "Make Food?";
                    else
                    {
                        panel.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Hole":
                    if (smc.myWood > 1)
                        panelMainText.text = "Use wood to repair hole?";
                    else
                    {
                        panel.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Med Cabinet":
                    if (smc.myMedicine > 0)
                        panelMainText.text = "Use medicine?";
                    else
                    {
                        panel.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Fire":
                    if (smc.myWood > 1)
                        panelMainText.text = "Use wood to make Fire?";
                    else
                    {
                        panel.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Door":
                    if (!hasBeenOutside)
                    {
                        hasBeenOutside = true;
                        panelMainText.text = "Leave house?";
                    }
                    else
                    {
                        //You've already left for the day
                        panel.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "House":
                    panelMainText.text = "Enter house for the night?";
                    break;

                //outdoor
                case "Church":
                    if(coinFlipHeads)//A
                    {
                        currentTag = "ChurchA";
                        msg = "You hear a series of discordant hymnals echoing from the windows of the old church." +
                        "You peer through the half open door and see the former priest humming to himself as he whips his own back." +
                        "‘I am a sinner in the eyes of an angry god’ he cries. He seems mostly distracted and you spy several destroyed pews that could make decent firewood.";
                        panelMainText.text = msg;
                        buttonAText.text = "Attempt to scavenge the wood";
                        buttonBText.text = "Don’t enter the church and go outside for items";
                    }
                    else//B
                    {
                        currentTag = "ChurchB";
                        msg = "You come upon the old church, and find it eerily silent. You find the elderly priest providing a sermon to hall of empty," +
                        "half destroyed pews. He spies you watching and beckons you to come and take communion";
                        panelMainText.text = msg;
                        buttonAText.text = "Take the communion";
                        buttonBText.text = "Keep an eye on him and try to gather some of the scrap wood";
                    }
                    break;

                case "Harbor":
                    if (coinFlipHeads)//A
                    {
                        currentTag = "HarborA";
                        msg = "The waves are breaking with aggressive frequency, you can’t imagine any fish that would be catchable in such tumultuous seas.";
                        panelMainText.text = msg;
                        buttonAText.text = "Scavenge for driftwood";
                        buttonBText.text = "Take a short rest to the sound of the crashing waves";
                    }
                    else//B
                    {
                        currentTag = "HarborB";
                        msg = "You come upon a calm sea," +
                            "and spy several fisherman coming home on makeshift boats. A fisherman spots you from a distance. “Greetings young’n”," +
                            "the grizzled fisherman hollered as he waved. You approach him and find a surprising number of fish in the man’s battered vessel. “That sure is a nice catch”" +
                            "you say to the man. “Ya got a good eye, kid, I’ll trade ya a few of ‘em if you got some wood to help me patch up my ship.";
                        panelMainText.text = msg;
                        buttonAText.text = "Barter with them for some of their catch";
                        buttonBText.text = "Try your own hand at fishing with your makeshift rod";
                    }
                    break;

                case "Hospital":
                    if (coinFlipHeads)//A
                    {
                        currentTag = "HospitalA";
                        msg = "To your surprise, you find a small staff of EMTs operating a makeshift emergency room in a circle of tireless ambulances outside the hospital.";
                        panelMainText.text = msg;
                        buttonAText.text = "See if they can patch you up";
                        buttonBText.text = "Offer to trade for some of their medicine";
                    }
                    else//B
                    {
                        currentTag = "HospitalB";
                        msg = "The city hospital seems rundown and abandoned. It is likely that the place has already been picked clean, but you investigate anyways" +
                            "just in case the desperate rummagers miss anything.";
                        panelMainText.text = msg;
                        buttonAText.text = "Search the cafeteria for leftover food";
                        buttonBText.text = "Raid what is left of the pharmacy for medicine";
                    }
                    break;

                //outdoor
//Hardware
                case "Hardware":
                    Debug.Log("HardwareABCase");
                    if (coinFlipHeads)
                    {
                        currentTag = "HardwareA";
                        panelMainText.text = "You arrive at the hardware store, remembering how happy your father was every time he came to this once bustling place. You feel extra lonely seeing the store abandoned and empty.";
                        buttonAText.text = "Scavenge for wood";
                        buttonBText.text = "Search for tools";
                    }
                    else
                    {
                        currentTag = "HardwareB";
                        panelMainText.text = "Your hear the sounds of construction ringing out from the back lot. You peek around the corner of the building and see a burly man sawing huge chunks of plywood into more manageable sections. He stops and stares at you for a while and continues to cut wood.";
                        buttonAText.text = "Cautiously approach";
                        buttonBText.text = "Back away carefuly and look elsewhere";
                    }
                    break;
//Forest
                case "Forest":
                    if (coinFlipHeads)
                    {
                        currentTag = "ForestA";
                        panelMainText.text = "As you venture deeper into the forest, the trees begin to block out most of the sunlight. Through the scattered light you spy a small doe drinking from a muddy pond.";
                        buttonAText.text = "Hunt the deer with your makeshift bow";
                        buttonBText.text = "Leave the animal in peace and try to snap some of the larger branches off to bring home.";
                    }
                    else
                    {
                        currentTag = "ForestB";
                        panelMainText.text = "Most of the once lush trees are dead and brittle, but you do find a few berry bushes and mushrooms under some of the in what is left of the undergrowth.";
                        buttonAText.text = "Harvest the berries and mushrooms ";
                        buttonBText.text = "Try to find usable wood";
                    }
                    break;
//Grocery
                case "Grocery":
                    if(coinFlipHeads)
                    {
                        currentTag = "GroceryA";
                        panelMainText.text = "The shelves of your local grocery store are mostly picked clean, but you manage to find several fallen over shelves amongst the empty aisles.";
                        buttonAText.text = "Search for food";
                        buttonBText.text = "Dismantle the shelf for wood";
                    }
                    else
                    {
                        currentTag = "GroceryB";
                        panelMainText.text = "A makeshift swap meet has formed outside the store. Individuals are selling their minor possessions or garden grown vegetables. You find a wheelchair-bound women offering surprisingly healthy produce.";
                        buttonAText.text = "Trade medicine for food";
                        buttonBText.text = "Trade Wood for food";
                    }
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        ObjectInteracted(collider.tag);
    } 

    public void OperateOnTag(string tag)
    {
        switch (tag)
        {
            case "Bed":
                if (leftChoice)
                {
                    //Sleep
                    hasBeenOutside = false;
                    functions.NightEvent();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                buttonAText.text = "Yes";
                buttonBText.text = "No";
                currentTag = "";
                canControl = true;
                break;
            case "Stove":
                if (!momDead)
                {
                    if (leftChoice)
                    {
                        //Who to give food to?
                        currentTag = "Stove2";
                        panelMainText.text = "Feed Mom or Yourself?";
                        buttonAText.text = "Feed Mom";
                        buttonBText.text = "Feed Yourself";
                    }
                    else
                    {
                        panel.gameObject.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                }
                else
                {
                    if (leftChoice)
                    {
                        //Give food to self
                        functions.SelfEatFood();
                    }
                    canControl = true;
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
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
                panelMainText.text = "";
                buttonAText.text = "Yes";
                buttonBText.text = "No";
                currentTag = "";
                break;

            case "Hole":
                if(leftChoice)
                {
                    Debug.Log("patch the hole");
                    functions.HomeRepairRoof();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                canControl = true;
                break;

            case "Med Cabinet":
                if (!momDead)
                {
                    if (leftChoice)
                    {
                        //Who to give medicine to?
                        currentTag = "Med Cabinet 2";
                        panelMainText.text = "Heal Mom or Yourself?\nCan only heal each once per Day";
                        buttonAText.text = "Heal Mom";
                        buttonBText.text = "Heal Yourself";
                    }
                    else
                    {
                        panel.gameObject.SetActive(false);
                        panelMainText.text = "";
                        currentTag = "";
                        canControl = true;
                    }
                }
                else
                {
                    if (leftChoice)
                    {
                        //Give medicine to self
                        functions.SelfTakeMedicine();
                    }
                    canControl = true;
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
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
                panelMainText.text = "";
                buttonAText.text = "Yes";
                buttonBText.text = "No";
                currentTag = "";
                break;

            case "Fire":
                if (leftChoice)
                {
                    //Debug.Log("make the fire");
                    functions.CreateFire();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                canControl = true;
                break;

            //outdoors
            case "Door":
                if (leftChoice)
                {
                    //Leave House
                    sceneManager.load("FinalMap");
                    hasBeenOutside = true;
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;
            case "House":
                if (leftChoice)
                {
                    //Enter house
                    sceneManager.load("FinalHouse");
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "ChurchA":
                okPanel.gameObject.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "You begin stealthily picking through what remains of the pews, keeping a close eye on the man." +
                        "However, he hears you and turns and charges you with fanatical speed. You try to run but slip on pages torn from bibles." +
                        "“SINNER” He cries as he swings his whip at you, it scrapes across your back just as you escape.";
                    functions.ChurchA1();
                }
                else
                {
                    panelOkText.text = "You decide it was not worth the risk and instead search outside the church for usable items. You find a fruit tree and collect some to eat.";
                    functions.ChurchA2();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                break;
            case "ChurchB":
                okPanel.gameObject.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "As you take the piece of bread, and the sip of wine, the priest smiles and says" +
                        "“God will carry us through these dark times, here child take this” and hands you a hefty chunk of bread alongside some medicinal herbs.";
                    functions.ChurchB1();
                }
                else
                {
                    panelOkText.text = "The priest sees you picking at the pieces of the pews and calls out that he means you no harm," +
                        "he sees the frightened look on your face and sighs to himself, “very well child, take what you need”";
                    functions.ChurchB2();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                break;

            case "HarborA":
                okPanel.gameObject.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "Most of what you find is waterlogged and unusable. However, you manage to salvage a few planks from what is left of the lifeguard tower.";
                    functions.HarborA1();
                }
                else
                {
                    panelOkText.text = "Your limbs are heavy from the journey, and the crashing waves entrances you with its rhythmic relaxing sound, reminding you of the times" +
                        "your dad brought you to the beach, you smile at the memory as your drift off to a peaceful deep sleep.";
                    functions.HarborA2();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                break;
            case "HarborB":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "You give him your wood pieces and he gives you a bucket of his catch. You fall over slightly at the weight of the bucket." +
                        "You thank him and he winks at you.";
                    functions.HarborB1();
                }
                else
                {
                    panelOkText.text = "You notice that he has a spare rod next to him. " +
                        "You ask him if you can use the rod to catch fish. He agrees to lend you his spare rod and you fish alongside him." +
                        "After what seemed like an eternity, you feel a tug on your line. After struggling for what felt like hours, you catch a decent-sized fish." +
                        "The fisherman congratulates you on your catch while you return his equipment.";
                    functions.HarborB2();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                canControl = true;
                break;

            case "HospitalA":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "You cautiously approach the circle and one of the EMTs looks at you with fatherly concern." +
                        "“Jesus kid, you look like you have had a rough week, let us take care of those cuts and bruises.” After tending to your injuries," +
                        "you feel much better and thank them deeply before returning home.";
                    functions.HospitalA1();
                }
                else
                {
                    panelOkText.text = "You approach with what food you have and ask them men if they can trade any supplies. They look like they haven’t eaten much and with a" +
                        "quick glance around they toss you 2 packets of medicine in exchange for a can of food.";
                    functions.HospitalA2();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                break;
            case "HospitalB":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "Underneath the layers of moldy, leftover food and empty trays you manage to find a few unspoiled cans of food." +
                        "You mutter yourself that hospital food is better than nothing.";
                    functions.HospitalB1();
                }
                else
                {
                    panelOkText.text = "Knocked over shelves and empty pill bottles are strewn across the floor. You manage to crawl under a pair of shelves" +
                        "and find a couple medicine packs wedged behind one of the shelves.";
                    functions.HospitalB2();
                }
                panel.gameObject.SetActive(false);
                panelMainText.text = "";
                currentTag = "";
                break;
//hardware
            case "HardwareA":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "In the lumber section you manage to find a few relatively undamaged boards of plywood. You awkwardly hoist them onto your back and begin the walk home.";
                    functions.HardwareA1();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                else
                {
                    panelOkText.text = "Hammers, screwdrivers, nails: it’s all still here. You grab a small bucket and patrol the aisles grabbing whatever you recognized from that DIY house projects show your dad used to watch.";
                    functions.HardwareA2();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                break;
//Hardware
            case "HardwareB":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "You see the man sanding down the damaged planks into finer lumber. He looks up again from his work and sees" +
                        "you carefully walking towards him. He pulls off his glasses and beckons you over. “Hey there, kid. Could you run over there and get me my tools?" +
                        "You do that and I’ll make sure you don’t walk home empty handed.” You quickly make it to his shed and grab his stuff. He thanks you and tells you to" +
                        "grab as much wood as you can.";
                    functions.HardwareB1();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                else
                {
                    panelOkText.text = "Who knows what that guy was up to, especially with all those sharp tools laying about, better to play it safe. You walk to the old employee’s lounge and find some canned goods. You take them hoping the man doesn’t mind.";
                    functions.HardwareB2();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                break;
//forest
            case "ForestA":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "The bow thrums and your arrow manages to hit the doe in the neck. The animal gurgles her yelps in pain and runs off a short distance before collapsing with you in tow. Under your breath you thank those archery lessons from summer camp. Finally the doe succumbs to its wound and you begin to slowly drag the carcass back home. “If you must hunt, make sure you waste none of the animal’s sacrifice” your mom used to say.";
                    functions.ForestA1();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panelOkText.text = "“Enough things have died around this town, this poor fella probably lost his parents too” you say as you begin to tear at nearby branches. With a solid crack you dislodge a sizable branch from a dead tree, out of the corner of your eye you see the doe sprint off deeper into the forest.";
                    functions.ForestA2();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                break;

            case "ForestB":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "You recognize the edible berries from back when your parents took you to the woods to go berry foraging. You pick the bushes and logs clean of their bounty. It’s not much, but it’s better than nothing.";
                    functions.ForestB1();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                else
                {
                    panelOkText.text = "Most of these trees yield useless wood. You poke around the ground trying to find a few larger branches with some strength left in them. You finally find one, hoist half of it on your shoulder and begin dragging it home.";
                    functions.ForestB2();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                break;

//grocery
            case "GroceryA":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    //Leave House
                    //function to leave house called here
                    panelOkText.text = "It pays to be small sometimes, you quip as you crawl under a few collapsed shelves. Jackpot -- you find several cans of soup that must have rolled under after the shelves collapsed.";
                    functions.GroceryA1();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                else
                {
                    panelOkText.text = "No use crawling around on the floor for whatever the rats left behind. A few of the shelves still have some sturdy planks that you manage to pry free. Lifting one plank reveals medicine, which you take.";
                    functions.GroceryA2();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                break;

            case "GroceryB":
                okPanel.SetActive(true);
                if (leftChoice)
                {
                    panelOkText.text = "'Excuse me, Miss.' you say looking at the cornucopia on display on her cart. “How may I help you, child”. She replies sweetly. “How much for the pumpkin, I’ve only seen them in story books. I have medicine to trade” “Lord knows I could use a few planks to fix up my old ramp, I'll trade you the pumpkin for one of those planks,” You put wood alongside her stand and grab the pumpkin wondering what you can make at home with it.";
                    functions.GroceryB1();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                else
                {
                    panelOkText.text = "'Excuse me, Miss.' you say looking at the cornucopia on display on her cart. “How may I help you, child”. She replies sweetly. “How much for the pumpkin, I’ve only seen them in story books. I have medicine to trade” “Lord knows I could use a few of those, toss me one and the pumpkin is all yours,” You hand over medicine and grab the pumpkin wondering what you can make at home with it.";
                    functions.GroceryB2();
                    panel.gameObject.SetActive(false);
                    panelMainText.text = "";
                    currentTag = "";
                }
                break;
        }
        functions.UpdateAll();
        CheckForDeaths();
        if (smc.myDays >= 6)
        {
            gameWon = true;
        }
    }

    private void CheckForDeaths()
    {
        if (smc.playerHP <= 0 || smc.shelterHP <= 0)
        {
            gameOver = true;
        }
        else if (smc.momHP < 0)
        {
            momDead = true;
        }
    }

    private void EndGame()
    {
        sceneManager.load("Game Over");
    }

    private void WinGame()
    {

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

    public void Ok()
    {
        panelOkText.text = "";
        okPanel.SetActive(false);
        canControl = true;
    }
}
