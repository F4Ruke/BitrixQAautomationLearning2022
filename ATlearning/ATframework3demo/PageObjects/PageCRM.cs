using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class PageCRM
    {
        private static void clickNewMenuItem(WebItem menu_item, WebItem new_menu_item)
        {
            //  Кликает по кнопке "Лиды"

            if (!menu_item.WaitElementDisplayed())
            {
                var btn_more = new WebItem("//div[@id='crm_control_panel_menu_more_button']//span[@class='main-buttons-item-text-title']",
                    "Кнопка 'Ещё'");
                btn_more.Click();

                new_menu_item.Click();
            }
            else
                menu_item.Click();
        }
        internal LeadsPageCRM openLeadsPage()
        {
            //  Открывает страницу "Лиды"

            var page_title = new WebItem("//span[@id='pagetitle']", "Название страницы");

            if (page_title.WaitElementDisplayed())
                if (page_title.InnerText() == "Лиды")
                    return new LeadsPageCRM();

            var btn_leads = new WebItem("//div[@id='crm_control_panel_menu_menu_crm_lead']//span[@class='main-buttons-item-text-title']",
                "Кнопка 'Лиды'");

            var new_btn_leads = new WebItem("//a[@title='Список лидов']", "Новая кнопка 'Лиды'");

            clickNewMenuItem(btn_leads, new_btn_leads);

            return new LeadsPageCRM();
        }
    }
}
