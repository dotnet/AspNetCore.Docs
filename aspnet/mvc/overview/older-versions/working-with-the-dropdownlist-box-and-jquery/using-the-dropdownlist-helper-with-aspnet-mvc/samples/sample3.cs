@{

    ViewBag.Title = "Category Select";

    Layout = "~/Views/Shared/_Simple_Layout.cshtml";

}

@using (Html.BeginForm("CategoryChosen", "Home", FormMethod.Get)) {

    <fieldset>

            Movie Type

            @Html.DropDownList("MovieType")

        <p>

            <input type="submit" value="Submit" />

        </p>

    </fieldset>

}