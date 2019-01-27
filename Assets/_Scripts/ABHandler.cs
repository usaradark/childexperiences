using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABHandler : MonoBehaviour
{
    public bool coinFlipHeads;
    //public float charaSpeed;
    public GameObject eventHandler;
    public GameObject statManager;
    public GameObject panel;

    //private CharacterController myController;
    private EventFunctions functions;

    private StatsManagerController smc;
    private string currentTrigger;
    private bool hasBeenOutside;

    public bool canControl;

    public string currentTag;

    bool leftChoice = true;

    // Start is called before the first frame update
    void Start()
    {
        //myController = GetComponent<CharacterController>();
        functions = eventHandler.GetComponent<EventFunctions>();
        smc = statManager.GetComponent<StatsManagerController>();
        currentTrigger = "";
        canControl = true;
        hasBeenOutside = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            string msg = "";
            switch (currentTag)
            {
                case "Stove":
                    if (smc.myFood > 0)
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Make Food?";
                    else
                    {
                        panel.SetActive(false);
                        panel.transform.GetChild(0).GetComponent<Text>().text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Hole":
                    if (smc.myWood > 1)
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Use wood to repair hole?";
                    else
                    {
                        panel.SetActive(false);
                        panel.transform.GetChild(0).GetComponent<Text>().text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Med Cabinet":
                    if (smc.myMedicine > 0)
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Use medicine?";
                    else
                    {
                        panel.SetActive(false);
                        panel.transform.GetChild(0).GetComponent<Text>().text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Fire":
                    if (smc.myWood > 1)
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Use wood to make Fire?";
                    else
                    {
                        panel.SetActive(false);
                        panel.transform.GetChild(0).GetComponent<Text>().text = "";
                        currentTag = "";
                        canControl = true;
                    }
                    break;
                case "Door":
                    if (!hasBeenOutside)
                    {
                        hasBeenOutside = true;
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Leave house?";
                    }
                    break;

                //outdoor
                case "Church":
                    if(coinFlipHeads)//A
                    {
                        currentTag = "ChurchA";
                        msg = "You hear a series of discordant hymnals echoing from the windows of the old church." +
                        "You peer through the half open door and see the former priest humming to himself as he whips his own back." +
                        "‘I am a sinner in the eyes of an angry god’ he cries. He seems mostly distracted and you spy several destroyed pews that could make decent firewood.";
                        panel.transform.GetChild(0).GetComponent<Text>().text = msg;
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Attempt to scavenge the wood";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Don’t enter the church and go outside for items";
                    }
                    else//B
                    {
                        currentTag = "ChurchB";
                        msg = "You come upon the old church, and find it eerily silent. You find the elderly priest providing a sermon to hall of empty," +
                        "half destroyed pews. He spies you watching and beckons you to come and take communion";
                        panel.transform.GetChild(0).GetComponent<Text>().text = msg;
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Take the communion";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Keep an eye on him and try to gather some of the scrap wood";
                    }
                    break;

                case "Harbor":
                    if (coinFlipHeads)//A
                    {
                        currentTag = "HarborA";
                        msg = "The waves are breaking with aggressive frequency, you can’t imagine any fish that would be catchable in such tumultuous seas.";
                        panel.transform.GetChild(0).GetComponent<Text>().text = msg;
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Scavenge for driftwood";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Take a short rest to the sound of the crashing waves";
                    }
                    else//B
                    {
                        currentTag = "HarborB";
                        msg = "You come upon a calm sea," +
                            "and spy several fisherman coming home on makeshift boats. A fisherman spots you from a distance. “Greetings young’n”," +
                            "the grizzled fisherman hollered as he waved. You approach him and find a surprising number of fish in the man’s battered vessel. “That sure is a nice catch”" +
                            "you say to the man. “Ya got a good eye, kid, I’ll trade ya a few of ‘em if you got some wood to help me patch up my ship.";
                        panel.transform.GetChild(0).GetComponent<Text>().text = msg;
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Barter with them for some of their catch";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Try your own hand at fishing with your makeshift rod";
                    }
                    break;

                case "Hospital":
                    if (coinFlipHeads)//A
                    {
                        currentTag = "HospitalA";
                        msg = "To your surprise, you find a small staff of EMTs operating a makeshift emergency room in a circle of tireless ambulances outside the hospital.";
                        panel.transform.GetChild(0).GetComponent<Text>().text = msg;
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "See if they can patch you up";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Offer to trade for some of their medicine";
                    }
                    else//B
                    {
                        currentTag = "HospitalB";
                        msg = "The city hospital seems rundown and abandoned. It is likely that the place has already been picked clean, but you investigate anyways" +
                            "just in case the desperate rummagers miss anything.";
                        panel.transform.GetChild(0).GetComponent<Text>().text = msg;
                        panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Search the cafeteria for leftover food";
                        panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Raid what is left of the pharmacy for medicine";
                    }
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
                    panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Feed Mom";
                    panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Feed Yourself";
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
                panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Yes";
                panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "No";
                currentTag = "";
                break;

            case "Hole":
                if(leftChoice)
                {
                    Debug.Log("patch the hole");
                    functions.HomeRepairRoof();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;

            case "Med Cabinet":
                if (leftChoice)
                {
                    //Who to give medicine to?
                    currentTag = "Med Cabinet 2";
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Heal Mom or Yourself?";
                    panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Heal Mom";
                    panel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Heal Yourself";
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
                    Debug.Log("make the fire");
                    functions.CreateFire();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;

            //outdoors
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
            case "ChurchA":
                if (leftChoice)
                {
                    Debug.Log("You begin stealthily picking through what remains of the pews, keeping a close eye on the man." +
                        "However, he hears you and turns and charges you with fanatical speed. You try to run but slip on pages torn from bibles." +
                        "“SINNER” He cries as he swings his whip at you, it scrapes across your back just as you escape.");
                    functions.ChurchA1();
                }
                else
                {
                    Debug.Log("You decide it was not worth the risk and instead search outside the church for usable items. You find a fruit tree and collect some to eat.");
                    functions.ChurchA2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;
            case "ChurchB":
                if (leftChoice)
                {
                    Debug.Log("As you take the piece of bread, and the sip of wine, the priest smiles and says" +
                        "“God will carry us through these dark times, here child take this” and hands you a hefty chunk of bread alongside some medicinal herbs.");
                    functions.ChurchB1();
                }
                else
                {
                    Debug.Log("The priest sees you picking at the pieces of the pews and calls out that he means you no harm," +
                        "he sees the frightened look on your face and sighs to himself, “very well child, take what you need”");
                    functions.ChurchB2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;

            case "HarborA":
                if(leftChoice)
                {
                    Debug.Log("Most of what you find is waterlogged and unusable. However, you manage to salvage a few planks from what is left of the lifeguard tower.");
                    functions.HarborA1();
                }
                else
                {
                    Debug.Log("Your limbs are heavy from the journey, and the crashing waves entrances you with its rhythmic relaxing sound, reminding you of the times" +
                        "your dad brought you to the beach, you smile at the memory as your drift off to a peaceful deep sleep.");
                    functions.HarborA2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;
            case "HarborB":
                if (leftChoice)
                {
                    Debug.Log("You give him your wood pieces and he gives you a bucket of his catch. You fall over slightly at the weight of the bucket." +
                        "You thank him and he winks at you.");
                    functions.HarborB1();
                }
                else
                {
                    Debug.Log("You notice that he has a spare rod next to him. " +
                        "You ask him if you can use the rod to catch fish. He agrees to lend you his spare rod and you fish alongside him." +
                        "After what seemed like an eternity, you feel a tug on your line. After struggling for what felt like hours, you catch a decent-sized fish." +
                        "The fisherman congratulates you on your catch while you return his equipment.");
                    functions.HarborB2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;

            case "HospitalA":
                if (leftChoice)
                {
                    Debug.Log("You cautiously approach the circle and one of the EMTs looks at you with fatherly concern." +
                        "“Jesus kid, you look like you have had a rough week, let us take care of those cuts and bruises.” After tending to your injuries," +
                        "you feel much better and thank them deeply before returning home.");
                    functions.HospitalA1();
                }
                else
                {
                    Debug.Log("You approach with what food you have and ask them men if they can trade any supplies. They look like they haven’t eaten much and with a" +
                        "quick glance around they toss you 2 packets of medicine in exchange for a can of food.");
                    functions.HospitalA2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;
            case "HospitalB":
                if (leftChoice)
                {
                    Debug.Log("Underneath the layers of moldy, leftover food and empty trays you manage to find a few unspoiled cans of food." +
                        "You mutter yourself that hospital food is better than nothing.");
                    functions.HospitalB1();
                }
                else
                {
                    Debug.Log("Knocked over shelves and empty pill bottles are strewn across the floor. You manage to crawl under a pair of shelves" +
                        "and find a couple medicine packs wedged behind one of the shelves.");
                    functions.HospitalB2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;
//hardware
            case "HardwareA":
                if (leftChoice)
                {
                    Debug.Log("In the lumber section you manage to find a few relatively undamaged boards of plywood. You awkwardly hoist them onto your back and begin the walk home.");
                    functions.HardwareA1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("Hammers, screwdrivers, nails: it’s all still here. You grab a small bucket and patrol the aisles grabbing whatever you recognized from that DIY house projects show your dad used to watch.");
                    functions.HardwareA2();
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
                    functions.HardwareB1();
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    Debug.Log("Who knows what that guy was up to, especially with all those sharp tools laying about, better to play it safe. You walk to the old employee’s lounge and find some canned goods. You take them hoping the man doesn’t mind.");
                    functions.HardwareB2();
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
