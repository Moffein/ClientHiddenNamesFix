using BepInEx;
using System;
using RoR2;

namespace R2API.Utils
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ManualNetworkRegistrationAttribute : Attribute
    {
    }
}
namespace ClientHiddenNamesFix
{
    [BepInPlugin("com.Moffein.ClientHiddenNamesFix", "ClientHiddenNamesFix", "1.0.0")]
    public class ClientHiddenNamesFix : BaseUnityPlugin
    {
        private void Awake()
        {
            RoR2.Stage.onStageStartGlobal += Stage_onStageStartGlobal;
        }

        private void Stage_onStageStartGlobal(Stage obj)
        {
            foreach (NetworkUser netUser in NetworkUser.instancesList)
            {
                if (netUser.userName.Equals("???")) netUser.UpdateUserName();
            }
        }
    }
}
