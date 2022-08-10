using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class LeadsPageCRM
    {
        internal AddLeadsForm openAddLeadsForm()
        {
            //  Открывает форму создания Лида

            var btn_add = new WebItem("//div[@id='toolbar_lead_list_button_0_anchor']", "Кнопка 'Добавить'");
            btn_add.Click();

            var add_lead_form = new WebItem("//iframe[@class='side-panel-iframe']", "Форма создания Лида");
            add_lead_form.SwitchToFrame();

            return new AddLeadsForm();
        }
    }
}
