using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_LeadsCRM : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Добавление Лида в CRM", homePage => AddContactCRM(homePage)),
            };
        }
        void AddContactCRM(PortalHomePage homePage)
        {
            homePage
                .LeftMenu
                .openCRM()  //  Открыть страницу CRM
                .openLeadsPage()  //  Открыть страницу Лид
                .openAddLeadsForm()  //  Открыть форму создания Лида
                .addFistName("Анатолий")  //  Добавить имя
                .addLastName("Иванов")  //  Добавить Фамилию
                .isAddFieldString()  //  Проверить наличие добавленных полей (Если есть удаляет)
                .addFieldString()  //  Добавить поле в форму создания Лида
                .addDescription("Бизнесмен")  //  Добавить описание в созданное поле
                .save()  //  Сохранить Лида
                .isSave();  //  Проверить создание Лида
        }
    }
}
