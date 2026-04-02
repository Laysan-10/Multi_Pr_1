using UnityEngine;
using Unity.Netcode;

public class Spawn : NetworkBehaviour
{
    [SerializeField] private Material hostMaterial;
    [SerializeField] private Material clientMaterial;
    private MeshRenderer meshRenderer;

    private void Awake() => meshRenderer = GetComponent<MeshRenderer>();

    public override void OnNetworkSpawn()
    {
        if (meshRenderer == null)
            return;

        // OwnerClientId == 0 соответствует Host (первый подключившийся)
        if (OwnerClientId == 0)
            meshRenderer.material = hostMaterial;
        else
            meshRenderer.material = clientMaterial;
    }
}