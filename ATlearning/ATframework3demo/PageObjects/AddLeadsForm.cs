using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;


namespace ATframework3demo.PageObjects
{
    public class AddLeadsForm
    {
        internal AddLeadsForm addFistName(string fist_name)
        {
            //  Добавление имени

            var first_name_field = new WebItem("//input[@id='name_text']", "Поле 'Имя'");
            first_name_field.SendKeys(fist_name);

            return new AddLeadsForm();
        }
        internal AddLeadsForm addLastName(string last_name)
        {
            //  Добавление фамилии

            var last_name_field = new WebItem("//input[@id='last_name_text']", "Поле 'Фамилия'");
            last_name_field.SendKeys(last_name);

            return new AddLeadsForm();
        }
        internal AddLeadsForm isAddFieldString()
        {
            //  Проверка наличия добавленных полей (если есть удаляет)

            int count_string_fields;

            var text_field = new WebItem("//textarea[@class='ui-entity-editor-field-textarea']", "Поле 'Дополнительно об источнике'");
            text_field.Click();

            var string_field = new WebItem("//div[@class='ui-entity-editor-content-block ui-entity-editor-content-block-field-custom-text']//div[@class='ui-entity-editor-block-context-menu']",
                "Поле 'Новая строка'");

            if (string_field.WaitElementDisplayed())
            {
                count_string_fields = WebItem.DefaultDriver.FindElements(By.XPath("//div[@class='ui-entity-editor-content-block ui-entity-editor-content-block-field-custom-text']//div[@class='ui-entity-editor-block-context-menu']")).Count();

                for (int i = 0; i < count_string_fields; i++)
                {
                    var btn_editor = new WebItem("//div[@class='ui-entity-editor-content-block ui-entity-editor-content-block-field-custom-text'][1]//div[@class='ui-entity-editor-block-context-menu']",
                        "Дополнительные настройки поля");
                    btn_editor.Click();

                    var btn_hide = new WebItem("//body[@class='crm-iframe-popup crm-detail-page template-bitrix24 crm-iframe-popup-no-scroll task-iframe-popup grid-mode top-menu-mode top-menu-mode']//span[@class='menu-popup-item menu-popup-no-icon '][1]",
                        "Кнопка 'Скрыть'");
                    btn_hide.Click();

                    Thread.Sleep(2000);
                }
            }

            return new AddLeadsForm();
        }
        internal AddLeadsForm addFieldString()
        {
            //  Создание поля типа "Строка"

            var btn_add_field = new WebItem("//div[@data-cid='main']//span[@class='ui-entity-editor-content-create-lnk']",
               "Кнопка 'Создать поле'");
            btn_add_field.Click();

            var btn_add_field_string = new WebItem("//span[@class='ui-entity-editor-popup-create-field-item'][1]",
                "Кнопка добавления поля 'Строка'");
            btn_add_field_string.Click();

            var btn_save = new WebItem("//span[@class='ui-btn ui-btn-primary']",
                "Кнопка 'Сохранить'");
            btn_save.Click();

            return new AddLeadsForm();
        }
        internal AddLeadsForm addDescription(string description)
        {
            //  Добавление описания в созданное поле

            var new_string_field = new WebItem("//input[@class='fields string ']", "Поле 'Новая строка'");
            new_string_field.SendKeys(description);

            return new AddLeadsForm();
        }
        internal CreatedLeadForm save()
        {
            //  Сохранение Лида

            var btn_save = new WebItem("//button[@class='ui-btn ui-btn-success']", "Кнопка 'Сохранить'");
            btn_save.Click();

            var warn = new WebItem("//div[@id='lead_0_details_editor_dup_warn']//span[@class='popup-window-button popup-window-button-create']",
                "Сообщение о подозрение на дубликаты");

            if (warn.WaitElementDisplayed())
                warn.Click();

            return new CreatedLeadForm();
        }
    }
}
