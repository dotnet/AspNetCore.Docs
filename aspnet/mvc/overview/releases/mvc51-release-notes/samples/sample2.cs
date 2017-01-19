@if (EnumHelper.IsValidForEnumHelper(ViewData.ModelMetadata))
{
    @Html.EnumDropDownListFor(model => model, htmlAttributes: new { @class = "form-control" })
}
@if (EnumHelper.IsValidForEnumHelper(ViewData.ModelMetadata))
{
    foreach (SelectListItem item in EnumHelper.GetSelectList(ViewData.ModelMetadata,
(Enum)Model)) { … }
}