using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DelayStartWaitingRoomController : MonoBehaviourPunCallbacks
{
    #region Fields
    private PhotonView photonView;

    [SerializeField]
    private int multiplayersceneindex;
    [SerializeField]
    private int Menusceneindex;
    private int playercount;
    private int roomsize;
    [SerializeField]
    private int minplayerstostart;

    [SerializeField]
    private Text roomcointdisplay;
    [SerializeField]
    private Text timertostart;

    private bool readytocoundown;
    private bool readytoStart;
    private bool startingGame;

    private float timertostartgame;
    private float notfullgametimer;
    private float fullgametimer;

    [SerializeField]
    private float maxwaittime;
    [SerializeField]
    private float maxgamefullwaittime;
    #endregion
    #region Unity Methods
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        fullgametimer = maxgamefullwaittime;
        notfullgametimer = maxwaittime;
        timertostartgame = maxwaittime;

        playercountupdate();

        
    }
    #endregion
    #region Custom Methods
    private void playercountupdate()
    {
        playercount = PhotonNetwork.PlayerList.Length;
        roomsize = PhotonNetwork.CurrentRoom.MaxPlayers;
        roomcointdisplay.text = playercount + ":" + roomsize;

        if (playercount == roomsize)
        {
            readytoStart = true;
        }
        else if (playercount >= minplayerstostart)
        {
            readytocoundown = true;
        }
        else
        {
            readytocoundown = false;
            readytoStart = false;
        }


    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        playercountupdate();

        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("RPC_SendTimer",RpcTarget.Others,timertostartgame);
        }
    }

    [PunRPC]
    private void RPC_SendTimer(float timein)
    {
        timertostartgame = timein;
        notfullgametimer = timein;
        if (timein < fullgametimer)
        {
            fullgametimer = timein;
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playercountupdate();
    }
    private void Update()
    {
        waitingformoreplayers();
        if(PhotonNetwork.PlayerList.Length == 2) 
        {
            print(PhotonNetwork.PlayerList[1]);
            print(PhotonNetwork.PlayerList[0]);
        }
    }

    private void waitingformoreplayers()
    {
        if (playercount <= 1)
        {
            ResetTimer();
        }

        if (readytoStart)
        {
            fullgametimer -= Time.deltaTime;
            timertostartgame = fullgametimer;
        }
        else if (readytocoundown)
        {
            notfullgametimer -= Time.deltaTime;
            timertostartgame = notfullgametimer;
        }
        string temptimer = string.Format("{0:00}",timertostartgame);
        timertostart.text = temptimer;
        if (timertostartgame <=0f)
        {
            if (startingGame)
            {
                return;
            }
            startGame();

        }

    }

    private void startGame()
    {
        startingGame = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayersceneindex);
    }

    private void ResetTimer()
    {
        timertostartgame = maxwaittime;
        notfullgametimer = maxwaittime;
        fullgametimer = maxgamefullwaittime;
    }

    public void DelayCancel()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(Menusceneindex);
    }
    #endregion
}
