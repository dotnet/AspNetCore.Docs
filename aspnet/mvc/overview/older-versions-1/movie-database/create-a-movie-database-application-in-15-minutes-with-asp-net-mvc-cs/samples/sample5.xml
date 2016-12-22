<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieApp.Models.Movie>" %> 

    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

       Create

    </asp:Content> 

    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 

        <h2>Create</h2> 

        <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %> 

        <% using (Html.BeginForm()) {%> 

            <fieldset>

                <legend>Fields</legend>

                <p>

                    <label for="Id">Id:</label>

                    <%= Html.TextBox("Id") %>

                    <%= Html.ValidationMessage("Id", "*") %>

                </p>

                <p>

                    <label for="Title">Title:</label>

                    <%= Html.TextBox("Title") %>

                    <%= Html.ValidationMessage("Title", "*") %>

                </p>

                <p>

                    <label for="Director">Director:</label>

                    <%= Html.TextBox("Director") %>

                    <%= Html.ValidationMessage("Director", "*") %>

                </p>

                <p>

                    <label for="DateReleased">DateReleased:</label>

                    <%= Html.TextBox("DateReleased") %>

                    <%= Html.ValidationMessage("DateReleased", "*") %>

                </p>

                <p>

                    <input type="submit" value="Create" />

                </p>

            </fieldset> 

        <% } %> 

        <div>

            <%=Html.ActionLink("Back to List", "Index") %>

        </div> 

    </asp:Content>