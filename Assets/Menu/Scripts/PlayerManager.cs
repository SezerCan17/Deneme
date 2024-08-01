using Photon.Pun;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;
    private SplitScreenManager splitScreenManager;

    // Karakterlerin ba�lang�� pozisyonlar�
    public Vector3 player1SpawnPosition; // �rne�in Player1 i�in
    public Vector3 player2SpawnPosition; // �rne�in Player2 i�in

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;

        // SplitScreenManager'� bulma
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

        // SplitScreenManager'� kontrol et ve oyuncular� ayarla
        if (splitScreenManager != null)
        {
            GameObject otherPlayer = PhotonNetwork.IsMasterClient
                ? GameObject.Find("OtherPlayerInstanceName") // Di�er oyuncunun GameObject'ini bulmak i�in bu ad� de�i�tirin
                : playerInstance;

            splitScreenManager.SetPlayerInstances(
                PhotonNetwork.IsMasterClient ? playerInstance : null,
                PhotonNetwork.IsMasterClient ? null : playerInstance
            );
        }
    }
}
