public class CustomRequestValidation : RequestValidator
{
	protected override bool IsValidRequestString(
	  HttpContext context, string value, 
	  RequestValidationSource requestValidationSource, 
	  string collectionKey, 
	  out int validationFailureIndex) 
	{...}
 }