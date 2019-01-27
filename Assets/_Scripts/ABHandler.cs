using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABHandler : MonoBehaviour
{

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
            canControl = false;
            panel.gameObject.SetActive(true);
            currentTag = collider.gameObject.tag;
            string msg = "";
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
                case "Church":
                    if(true)//A
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
                    if (true)//A
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
                    if (true)//A
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
                    functions.HarborB1();
                }
                else
                {
                    Debug.Log("Knocked over shelves and empty pill bottles are strewn across the floor. You manage to crawl under a pair of shelves" +
                        "and find a couple medicine packs wedged behind one of the shelves.");
                    functions.HarborB2();
                }
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                canControl = true;
                break;
        }
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
