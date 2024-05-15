using YooAsset;

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
            
            Log.Info($"Login success playerId:{response.PlayerId}");
            //这里就是到了游戏逻辑了，要继续用ET那套或者自己接入其它的，是不同项目不同的选择

            // root.GetComponent<PlayerComponent>().MyId = playerId;
            // await EventSystem.Instance.PublishAsync(root, new LoginFinish());
            YooAssets.LoadSceneAsync("Assets/GameAssets/Scenes/scene_home");
            await ETTask.CompletedTask;
        }
    }
}