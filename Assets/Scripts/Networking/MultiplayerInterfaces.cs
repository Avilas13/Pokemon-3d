namespace Pokemon3D.Networking
{
    // Multiplayer-ready abstraction so systems can switch from local to network authority.
    public interface IReplicationService
    {
        void ReplicatePlayerState(string playerId, string serializedState);
        void ReplicateCreatureState(string creatureId, string serializedState);
    }

    public interface ITradingService
    {
        bool TryStartTradeSession(string localPlayerId, string remotePlayerId);
    }
}
