using UnityEngine; 

/// <summary>
/// Отвечает за копоновку связей между модулями.
/// </summary>
public class СomposerPlayer : MonoBehaviour
{
 
    public GameObject Player;
    public GameObject GUIStateBandObject;
 
    private Spaceships.ISpaceship PlayerSpaceship; 

    private Spaceships.UI.GUI.GUIStateBand guiStateBand;
    private Spaceships.UI.IInputMoveAggregator MoveAggregator;

    // Use this for initialization
    void Start()
    {
        PlayerSpaceship = Player.GetComponent<Spaceships.ISpaceship>();     
        this.guiStateBand = GUIStateBandObject.GetComponent<Spaceships.UI.GUI.GUIStateBand>(); 
        this.guiStateBand.SpaceShip = PlayerSpaceship;
        MoveAggregator.PassLinkToMoveController(PlayerSpaceship.GetMoveController());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
