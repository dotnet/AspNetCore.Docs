namespace PoliciesAuthApp2.Pages
{
    // <snippet_AlcoholPurchaseModelClass>
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [Authorize(Policy = "AtLeast21")]
    public class AlcoholPurchaseModel : PageModel
    {
    }
    // </snippet_AlcoholPurchaseModelClass>
}
