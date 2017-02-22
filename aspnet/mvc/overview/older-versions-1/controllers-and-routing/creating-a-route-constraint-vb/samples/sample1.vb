routes.MapRoute( _
    "Product", _
    "Product/{productId}", _
    New With {.controller = "Product", .action = "Details"} _
)