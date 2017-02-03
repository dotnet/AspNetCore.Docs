routes.MapRoute( _
   "Product", _
   "Product/{productId}", _
   New With {.controller = "Product", .action = "Details"}, _
   New With {.productId = "\d+"} _
)