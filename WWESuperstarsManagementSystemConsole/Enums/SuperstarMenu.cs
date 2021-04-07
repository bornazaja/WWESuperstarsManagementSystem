using System.ComponentModel;

namespace WWESuperstarsManagementSystemConsole.Enums
{
    public enum SuperstarMenu
    {
        [Description("Return to main menu")]
        ReturnToMainMenu,

        [Description("Add")]
        Add,

        [Description("Update")]
        Update,

        [Description("Delete")]
        Delete,

        [Description("Find by id")]
        FindById,

        [Description("Show all")]
        ShowAll,

        [Description("Advanced search")]
        AdvancedSearch,

        [Description("Show total count")]
        ShowTotalCount
    }
}
