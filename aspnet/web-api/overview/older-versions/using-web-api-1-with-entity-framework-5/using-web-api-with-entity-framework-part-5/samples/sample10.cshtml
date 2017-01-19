@model ProductStore.Models.Product

@{
    ViewBag.Title = "Admin";
}

@section Scripts {
  @Scripts.Render("~/bundles/jqueryval")
  <script type="text/javascript" src="@Url.Content("~/Scripts/knockout-2.0.0.js")"></script> 
  <script type="text/javascript">
      function ProductsViewModel() {
          var self = this;
          self.products = ko.observableArray();

          var baseUri = '@ViewBag.ApiUrl';

          self.create = function (formElement) {
              // If valid, post the serialized form data to the web api
              $(formElement).validate();
              if ($(formElement).valid()) {
                  $.post(baseUri, $(formElement).serialize(), null, "json")
                      .done(function (o) { self.products.push(o); });
              }
          }

          self.update = function (product) {
              $.ajax({ type: "PUT", url: baseUri + '/' + product.Id, data: product });
          }

          self.remove = function (product) {
              // First remove from the server, then from the UI
              $.ajax({ type: "DELETE", url: baseUri + '/' + product.Id })
                  .done(function () { self.products.remove(product); });
          }

          $.getJSON(baseUri, self.products);
      }

      $(document).ready(function () {
          ko.applyBindings(new ProductsViewModel());
      })
  </script>
}

<h2>Admin</h2>
<div class="content">
    <div class="float-left">
    <ul id="update-products" data-bind="foreach: products">
        <li>
            <div>
                <div class="item">Product ID</div> <span data-bind="text: $data.Id"></span>
            </div>
            <div>
                <div class="item">Name</div> 
                <input type="text" data-bind="value: $data.Name"/>
            </div> 
            <div>
                <div class="item">Price ($)</div> 
                <input type="text" data-bind="value: $data.Price"/>
            </div>
            <div>
                <div class="item">Actual Cost ($)</div> 
                <input type="text" data-bind="value: $data.ActualCost"/>
            </div>
            <div>
                <input type="button" value="Update" data-bind="click: $root.update"/>
                <input type="button" value="Delete Item" data-bind="click: $root.remove"/>
            </div>
        </li>
    </ul>
    </div>

    <div class="float-right">
    <h2>Add New Product</h2>
    <form id="addProduct" data-bind="submit: create">
        @Html.ValidationSummary(true)
        <fieldset>
            <legend>Contact</legend>
            @Html.EditorForModel()
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    </form>
    </div>
</div>