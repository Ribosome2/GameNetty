namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            root.RemoveComponent<ClientSenderComponent>();
            
            ClientSenderComponent clientSenderComponent = root.AddComponent<ClientSenderComponent>();
            
            var response  = await clientSenderComponent.LoginAsync(account, password);

            if (response.Error != ErrorCode.ERR_Success)
            {
             
                Log.Error($"response Error{response.Error}");
                return;    
            }
            
            // Log.Info($"Login success playerId:{playerId}");

            // root.GetComponent<PlayerComponent>().MyId = playerId;
            //
            // await EventSystem.Instance.PublishAsync(root, new LoginFinish());
            await ETTask.CompletedTask;
        }
    }
}