

Microsoft.AspNet.JsonPatch.Helpers Namespace
============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/JsonPatch/Helpers/GetValueResult/index
   
   











.. dn:namespace:: Microsoft.AspNet.JsonPatch.Helpers


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.JsonPatch.Helpers.GetValueResult`
        Return value for the helper method used by Copy/Move.  Needed to ensure we can make a different
        decision in the calling method when the value is null because it cannot be fetched (HasError = true)
        versus when it actually is null (much like why RemovedPropertyTypeResult is used for returning
        type in the Remove operation).


