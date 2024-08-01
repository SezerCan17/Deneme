using Photon.Pun;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;
    private SplitScreenManager splitScreenManager;

    // Karakterlerin baþlangýç pozisyonlarý
    public Vector3 player1SpawnPosition; // Örneðin Player1 için
    public Vector3 player2SpawnPosition; // Örneðin Player2 için

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;

        // SplitScreenManager'ý bulma
        splitScreenManager = FindObjectOfType<SplitScreenManager>();

        if (pv.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController()
    {
        // Spawn pozisyonunu belirleyin
        Vector3 spawnPosition = PhotonNetwork.IsMasterClient ? player1SpawnPosition : player2SpawnPosition;

        GameObject playerInstance = PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", PhotonNetwork.IsMasterClient ? "PlayerController1" : "PlayerController2"),
            spawnPosition,
            Quaternion.identity
        );

        // SplitScreenManager'ý kontrol et ve oyuncularý ayarla
        if (splitScreenManager != null)
        {
            GameObject otherPlayer = PhotonNetwork.IsMasterClient
                ? GameObject.Find("OtherPlayerInstanceName") // Diðer oyuncunun GameObject'ini bulmak için bu adý deðiþtirin
                : playerInstance;

            splitScreenManager.SetPlayerInstances(
                PhotonNetwork.IsMasterClient ? playerInstance : null,
                PhotonNetwork.IsMasterClient ? null : playerInstance
            );
        }
    }
}
