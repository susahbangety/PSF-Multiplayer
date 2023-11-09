using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

namespace SheviaMultiplayer.Fusion
{
    public class FusionConnection : MonoBehaviour, INetworkRunnerCallbacks
    {
        public static FusionConnection instance;

        public bool connectOnAwake = false;
        [HideInInspector] public NetworkRunner networkRunner;

        [SerializeField] NetworkObject playerPrefab;
        [SerializeField] Transform playerSpawn;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            if(connectOnAwake == true)
                ConnectToRunner();
        }

        public async void ConnectToRunner()
        {
            if (networkRunner == null)
            {
                networkRunner = gameObject.AddComponent<NetworkRunner>();
            }

            await networkRunner.StartGame(new StartGameArgs()
            {
                GameMode = GameMode.Shared,
                SessionName = "TestRoom",
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("OnConnectedToServer");
            Debug.Log("Player ID : " +runner.GetPlayerUserId());

        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {

        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {

        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {

        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {

        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {

        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {

        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {

        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            Debug.Log("OnPlayerJoined");

            if (player == runner.LocalPlayer)
            {
                NetworkObject playerObject = runner.Spawn(playerPrefab, new Vector3(playerSpawn.position.x, 1, playerSpawn.position.z), Quaternion.identity, player);
                networkRunner.SetPlayerObject(networkRunner.LocalPlayer, playerObject);
                playerObject.tag = "Player";

                GameObject child1 = playerObject.transform.GetChild(0).gameObject;
                GameObject networkCharacter = child1.transform.GetChild(0).gameObject;
                GameObject characterModel = networkCharacter.transform.GetChild(1).gameObject;

                characterModel.SetActive(false);
            }
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {

        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {

        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {

        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {

        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {

        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {

        }
    }
}
