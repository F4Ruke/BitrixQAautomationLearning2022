using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.PageObjects
{
    public class CreatedLeadForm
    {
        internal CreatedLeadForm isSave()
        {
            var message = new WebItem("//div[@class='crm-entity-stream-content-event']//a[@href='#']",
                "Сообщение о создании Лида");

            if (message.AssertTextContains("Создан лид", default))
                Log.Info("Лид был создан");
            else
                Log.Error("Лид не был создан");

            return new CreatedLeadForm();
        }
    }
}
